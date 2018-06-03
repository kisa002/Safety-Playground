using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject panelBatting, panelHistory, panelSetting, panelMypage, panelMinigame;
    public Text textUsername, textKRW;

    private void Awake()
    {
        if (UIManager.Instance == null)
            UIManager.Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        ShowBatting();
    }

    private void Update()
    {
        textUsername.text = GameManager.Instance.username;
        textKRW.text = "KRW : " + string.Format("{0:#,###}", GameManager.Instance.krw);
    }

    public void ShowBatting()
    {
        panelBatting.SetActive(true);
        panelHistory.SetActive(false);
        panelSetting.SetActive(false);
        panelMypage.SetActive(false);
        panelMinigame.SetActive(false);
    }

    public void ShowHistory()
    {
        panelBatting.SetActive(false);
        panelHistory.SetActive(true);
        panelSetting.SetActive(false);
        panelMypage.SetActive(false);
        panelMinigame.SetActive(false);
    }

    public void ShowSetting()
    {
        panelBatting.SetActive(false);
        panelHistory.SetActive(false);
        panelSetting.SetActive(true);
        panelMypage.SetActive(false);
        panelMinigame.SetActive(false);
    }

    public void ShowMypage()
    {
        panelBatting.SetActive(false);
        panelHistory.SetActive(false);
        panelSetting.SetActive(false);
        panelMypage.SetActive(true);
        panelMinigame.SetActive(false);
    }

    public void ShowMinigame()
    {
        panelBatting.SetActive(false);
        panelHistory.SetActive(false);
        panelSetting.SetActive(false);
        panelMypage.SetActive(false);
        panelMinigame.SetActive(true);
    }
}
