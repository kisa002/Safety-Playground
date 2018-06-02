using Assets.Scripts.Related_Batting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultBtnPanel : BtnPanel {

    private int bettingPrice;
    private int gettedMoney;
    private int remainTime;

    private Text detail;

    private Image btnImg;

    private void Awake()
    {
        detail = transform.Find("Text").GetComponent<Text>();
        btnImg = transform.Find("WinBtn").GetComponent<Image>();
    }

    public void Initialize(int bettingPrice, int gettedMoney, int remainTime)
    {
        this.bettingPrice = bettingPrice;
        this.gettedMoney = gettedMoney;
        this.remainTime = remainTime;

        StartCoroutine(TakeRamainTime(remainTime));
    }

    IEnumerator TakeRamainTime(int remainTime)
    {
        float startTime = Time.time;
        btnImg.color = new Color(93, 95, 92);
        while(startTime + remainTime < Time.time)
        {
            yield return null;
        }

        if(bettingPrice != 0)
        {
            btnImg.color = new Color(72, 157, 40);
        }
        else
        {
            btnImg.color = new Color(170, 41, 41);
        }

        Debug.Log("색 변경");

    }

    public void BtnClick()
    {

    }
}
