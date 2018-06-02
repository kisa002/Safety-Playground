using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattingPanel : Singleton<BattingPanel>
{
    [SerializeField]
    private Text priceField;
    [SerializeField]
    private Button battingBtn;
    private Text battingBtnText;
    private Color originBattingBtnTextColor;

    [SerializeField]
    private Button canelBtn;

    private CanvasGroup canvasGroup;
   
    private TeamInfo curTeamInfo;

    private BatManager batManager;
    private PlayerManager playerManager;

    private void Awake()
    {
        batManager = BatManager.Instance;
        playerManager = PlayerManager.Instance;
        battingBtnText = battingBtn.transform.GetChild(0).GetComponent<Text>();
        originBattingBtnTextColor = battingBtnText.color;

        canvasGroup = GameObject.Find("CanvasGroup").GetComponent<CanvasGroup>();
    }

    public void Operate(TeamInfo teamInfo)
    {
        canvasGroup.blocksRaycasts = false;
        gameObject.SetActive(true);
        curTeamInfo = teamInfo;
    }

    public void Cancel()
    {
        canvasGroup.blocksRaycasts = true;
        gameObject.SetActive(false);
    }

    public void CheckToCanBat()
    {
        int battingPrice = int.Parse(priceField.text);
        if (battingPrice > playerManager.curPlayer.money)
        {
            battingBtnText.color = new Color(199, 199, 204);
            battingBtn.interactable = false;
        }
        else
        {
            battingBtnText.color = new Color(0, 122, 255);
            battingBtn.interactable = true;
        }
    }

    public void Bat()
    {
        int battingPrice = int.Parse(priceField.text);
        playerManager.curPlayer.money -= battingPrice;

        batManager.MakeBatInfo(curTeamInfo, battingPrice);
    }
	
}
