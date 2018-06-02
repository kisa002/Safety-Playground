using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public int money;
    public int type = -1;

    public int dir = 1;
    public float speed = 10f;

    public int blockType = -1;
    public int blockCount = 0;
    public int blockFill = 0;

    public Sprite sprBlock;
    public Sprite sprBlockFill;

    [SerializeField]
    GameObject textKRW;

    [SerializeField]
    GameObject[] miniGame;

    [SerializeField]
    GameObject[] block;

    [SerializeField]
    private Pin timingPin;

    public void ShowMiniGame(int type)
    {
        this.type = type;
        miniGame[type].SetActive(true);

        if(type == 1)
            ShowRandomBlock();
    }

    public void Back()
    {
        type = -1;

        blockType = -1;
        blockCount = 0;
        blockFill = 0;

        foreach (var game in miniGame)
            game.SetActive(false);

        for (int i = 0; i < block[blockType].transform.childCount; i++)
            block[blockType].transform.GetChild(i).GetComponent<Image>().sprite = sprBlock;

        foreach (var blo in block)
            blo.SetActive(false);

        //TODO ACTION

    }

    private void IncreaseMoney(int x, int y)
    {
        int t = Random.Range(x, y + 1);
        money += t;

        GameObject text = Instantiate(textKRW, transform);

        text.transform.SetParent(miniGame[type].transform);
        text.transform.localPosition = new Vector2(0, -425);
        text.transform.localScale = new Vector3(1, 1, 1);

        text.GetComponent<Text>().text = "KRW + " + t;
    }

    private void DecreaseMoney(int x, int y)
    {
        int t = Random.Range(x, y + 1);
        money -= t;

        GameObject text = Instantiate(textKRW, transform);

        text.transform.SetParent(miniGame[type].transform);
        text.transform.localPosition = new Vector2(0, -425);
        text.transform.localScale = new Vector3(1, 1, 1);

        text.GetComponent<Text>().text = "KRW - " + t;
    }

    public void ClickMe()
    {
        //money += Random.Range(1, 3);
        IncreaseMoney(1, 2);
    }

    public void TimingClick()
    {
        if (timingPin.isCheck)
            IncreaseMoney(5, 10);
        else
            DecreaseMoney(5, 10);

        timingPin.Init();
    }

    public void ShowRandomBlock()
    {
        if(blockType != -1)
            for (int i = 0; i < block[blockType].transform.childCount; i++)
                block[blockType].transform.GetChild(i).GetComponent<Image>().sprite = sprBlock;

        foreach (var blo in block)
            blo.SetActive(false);

        blockType = Random.Range(0, 3);
        block[blockType].SetActive(true);

        blockFill = 0;
        blockCount = block[blockType].transform.childCount;

        for (int i = 0; i < block[blockType].transform.childCount; i++)
            block[blockType].transform.GetChild(i).GetComponent<Image>().sprite = sprBlock;
    }

    public void BlockClick()
    {
        if(blockFill < blockCount)
            block[blockType].transform.GetChild(blockFill).GetComponent<Image>().sprite = sprBlockFill;

        blockFill++;

        if (blockFill > blockCount)
        {
            IncreaseMoney(3, 7);
            ShowRandomBlock();
        }
    }
}
