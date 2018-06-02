using Assets.Scripts.Related_Batting;
using SafetyPlay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ResultType
{
    Lose,
    Draw,
    Win
}

public class BettingSection : Singleton<BettingSection>
{
    [SerializeField]
    private float initY = 421.71f;
    [SerializeField]
    private float heightGap = 325;

    private Transform batBtnPanelParent;

    private ScrollManager scrollManager;
    private LinkedList<BetBtnPanel> batBtnPanels = new LinkedList<BetBtnPanel>();
    private LinkedList<ResultBtnPanel> resultBtnPanels = new LinkedList<ResultBtnPanel>();

    private void Awake()
    {
        scrollManager = GameObject.Find("GameScrollPanel").GetComponent<ScrollManager>();
        batBtnPanelParent = GameObject.Find("GameScrollPanel").transform;
    }

    public void Off()
    {    
        gameObject.SetActive(false);
        scrollManager.Stop();
    }

    public void On()
    {     
        gameObject.SetActive(true);

        scrollManager.ToOrigin();
        scrollManager.Start();
    }

    public void BetBtnDequeue()
    {
        var usedPanel = batBtnPanels.First;
        batBtnPanels.RemoveFirst();

        BetManager.Instance.betBtnPanelPool.Enqueue(usedPanel.Value as BetBtnPanel);
        Sort();
    }

    public void CreateGame(BettingGameInfo bettingGameInfo, BetBtnPanel betBtnPanel)
    {
        betBtnPanel.Initialize(bettingGameInfo);
    }

    public void CreateResult(int bettingPrice, int gettedMoney, int remainTime)
    {
        var newPanel = BetManager.Instance.resultBtnPanelPool.Dequeue();
        newPanel.Initialize(bettingPrice, gettedMoney, remainTime);
        resultBtnPanels.AddFirst(new LinkedListNode<ResultBtnPanel>(newPanel));
    }

    public void Sort()
    {
        int i = 0;
        var list1 = resultBtnPanels.ToList();
        for(; i < resultBtnPanels.Count; i++)
        {
            list1[i].transform.anchoredPosition = new Vector2(list1[i].transform.anchoredPosition.x, initY - (i * heightGap));
        }
        //todo ToList() = 가비지 폭탄
        var list2 = batBtnPanels.ToList();         
        for (; i < batBtnPanels.Count; i++)
        {
            list2[i].transform.anchoredPosition = new Vector2(list2[i].transform.anchoredPosition.x, initY - (i * heightGap));
        }
    }

}
