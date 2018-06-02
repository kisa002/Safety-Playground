using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BettingPanel : Singleton<BettingPanel>
{
    [SerializeField]
    private Text priceField;
    [SerializeField]
    private Button bettingBtn;
    private Text bettingBtnText;
    private Color originbettingBtnTextColor;

    [SerializeField]
    private Button canelBtn;

    private CanvasGroup canvasGroup;

    private BetManager betManager;
    private Player player;

    private new GameObject gameObject;

    private string curType;
    private BetBtnPanel curPanel;

    private float remainTime;
    private float multiple;

    private void Awake()
    {
        gameObject = base.gameObject;
        betManager = BetManager.Instance;
        player = Player.Instance;
        bettingBtnText = bettingBtn.transform.GetChild(0).GetComponent<Text>();
        originbettingBtnTextColor = bettingBtnText.color;

        canvasGroup = GameObject.Find("CanvasGroup").GetComponent<CanvasGroup>();
    }

    public void Operate(string type, BetBtnPanel curPanel, float remainTime, float multiple)
    {
        this.remainTime = remainTime;
        this.multiple = multiple;
        curType = type;
        canvasGroup.blocksRaycasts = false;
        gameObject.SetActive(true);
    }

    public void Cancel()
    {
        canvasGroup.blocksRaycasts = true;
        gameObject.SetActive(false);
        curPanel.isPanelOn = false;
    }

    public void CheckToCanBet()
    {
        int bettingPrice = int.Parse(priceField.text);
        if (bettingPrice > player.money)
        {
            bettingBtnText.color = new Color(199, 199, 204);
            bettingBtn.interactable = false;
        }
        else
        {
            bettingBtnText.color = new Color(0, 122, 255);
            bettingBtn.interactable = true;
        }
    }

    public void Bet()
    {
         curPanel.isBet = true;
        float gettedMoney = 0;
        int bettingPrice = int.Parse(priceField.text.Trim());

        if (curPanel.result == curType)
        {
            gettedMoney = bettingPrice * multiple;
        }

        BettingSection.Instance.CreateResult(int.Parse(priceField.text.Trim()), (int)gettedMoney, (int)remainTime);
    }
	
}
