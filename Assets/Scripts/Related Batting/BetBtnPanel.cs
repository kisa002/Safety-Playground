using Assets.Scripts.Related_Batting;
using SafetyPlay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetBtnPanel : BtnPanel
{
    private BettingGameInfo bettingGameInfo;

    private int gid;
    public string result;
    private float elapsed = 0;

    public bool isBet = false;
    private string bettedType;

    private float selectedMultiple;
    private float battedPrice;

    private float startTime;
    private float duration;


    private BettingSection battingSection;
    private WaitForSeconds waitOneSec;

    [SerializeField]
    private Button loseBtn;
    private Text loseBtnText;
    [SerializeField]
    private Button drawBtn;
    private Text drawBtnText;
    [SerializeField]
    private Button winBtn;
    private Text winBtnText;

    [SerializeField]
    private Text teamName;
    [SerializeField]
    private Text durationText;


    public bool isPanelOn = false;

    private void Awake()
    {
        waitOneSec = new WaitForSeconds(1f);

        loseBtnText = loseBtn.transform.GetChild(0).GetComponent<Text>();
        drawBtnText = drawBtn.transform.GetChild(0).GetComponent<Text>();
        winBtnText = winBtn.transform.GetChild(0).GetComponent<Text>();

        transform = GetComponent<RectTransform>();
    }

    public void Initialize(BettingGameInfo bettingGameInfo)
    {
        this.bettingGameInfo = bettingGameInfo;

        loseBtnText.text = bettingGameInfo.lose.ToString();
        drawBtnText.text = bettingGameInfo.draw.ToString();
        winBtnText.text = bettingGameInfo.win.ToString();

        duration = (float)(bettingGameInfo.date.TimeOfDay.TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds);
        durationText.text = $"{duration / 60}m {duration % 60}s)";

        teamName.text = bettingGameInfo.name;

        gid = bettingGameInfo.gid;

        result = bettingGameInfo.res;

        startTime = Time.time;


        StartCoroutine(CheckTime());
    }

    private IEnumerator CheckTime()
    {
        while (true)
        {
            if (!isPanelOn)
            {
                if (isBet)
                {
                    Stop();
                    yield break;
                }
                else if (elapsed > duration)
                {
                    Stop();
                    yield break;
                }

                elapsed += Time.deltaTime;
            }

            yield return waitOneSec;
        }
    }

    private void Stop()
    {
        battingSection.BetBtnDequeue();
    }

    public void BtnClick(string type)
    {
        isPanelOn = true;
        float multiple = 0;
        if(result == type)
        {
            switch (type)
            {
                case "LOSE":
                    multiple = bettingGameInfo.lose;
                    break;
                case "DRAW":
                    multiple = bettingGameInfo.draw;
                    break;
                case "WIN":
                    multiple = bettingGameInfo.win;
                    break;
            }
        }
        BettingPanel.Instance.Operate(type, this, duration - elapsed + UnityEngine.Random.Range(10, 15), multiple);
    }



}
