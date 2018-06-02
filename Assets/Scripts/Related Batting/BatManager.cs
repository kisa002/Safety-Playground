using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : Singleton<BatManager>
{
    [SerializeField]
    private BattingPanel battingPanel;

    private Queue<BattingInfo> battingInfoPool = new Queue<BattingInfo>();
    private Dictionary<TeamInfo, BattingInfo> battingInfos = new Dictionary<TeamInfo, BattingInfo>();

    private TeamManager teamManager;

    private void Awake()
    {
        teamManager = TeamManager.Instance;
        CacheBattingInfo();
    }

    private void CacheBattingInfo()
    {
        for (int i = 0; i < 50; i++)
        {
            battingInfoPool.Enqueue(new BattingInfo());
        }
    }

    public void Bat(GameObject battingBtn)
    {
        TeamInfo teamInfo = teamManager.teamInfos[battingBtn];
        battingPanel.Operate(teamInfo);
    }

    public void MakeBatInfo(TeamInfo teamInfo, int battingPrice)
    {
        BattingInfo usingBattingInfo = battingInfoPool.Dequeue();
        usingBattingInfo.Initialize(battingPrice);
    }
    
    private IEnumerator reloadBatResult()
    {
        yield return null;
    }

}
