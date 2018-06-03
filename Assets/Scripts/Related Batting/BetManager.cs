using SafetyPlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRest;

public class BetManager : Singleton<BetManager>
{
    private int lastestGid = 1;

    [SerializeField]
    private BetBtnPanel betBtnPanelStandard;
    [SerializeField]
    private ResultBtnPanel resultBtnPanelStandard;

    private BettingPanel bettingPanel;
    private BettingSection bettingSection;
    public Queue<BetBtnPanel> betBtnPanelPool = new Queue<BetBtnPanel>();
    public Queue<ResultBtnPanel> resultBtnPanelPool = new Queue<ResultBtnPanel>();



    private void Awake()
    {
        bettingSection = BettingSection.Instance;
        bettingPanel = BettingPanel.Instance;

        StartCoroutine(Load());
    }

    private void CacheBattingInfo()
    {
        for (int i = 0; i < 50; i++)
        {
            var newBatBtnPanel = Instantiate(betBtnPanelStandard);
            betBtnPanelPool.Enqueue(newBatBtnPanel);
            newBatBtnPanel.gameObject.SetActive(false);
        }

        for(int i = 0; i < 25; i++)
        {
            var newWinBtnPanel = Instantiate(resultBtnPanelStandard);
            resultBtnPanelPool.Enqueue(newWinBtnPanel);
            newWinBtnPanel.gameObject.SetActive(false);

        }
    }

    IEnumerator Load()
    {
        while (true)
        {
            StartCoroutine(LoadGame());
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator LoadGame()
    {
        // GET

        WWW www = new WWW("http://safetyplay.dothome.co.kr" + "/games");
        yield return www;

        BettingGameInfo[] bettingGameInfoes = JsonHelper.FromJson<BettingGameInfo>(www.text);

        var games = bettingGameInfoes;

        if (games[0].gid <= lastestGid)
        {
            int gap = games[0].gid - lastestGid;
            if (games.Length < gap + 1)
                yield break;

            for (int i = gap + 1; i < games.Length; i++)
            {
                bettingSection.CreateGame(games[i], betBtnPanelPool.Dequeue());
            }
        }

        bettingSection.Sort();
    }
   

}
