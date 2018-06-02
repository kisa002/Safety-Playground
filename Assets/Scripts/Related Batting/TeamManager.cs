using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : Singleton<TeamManager>
{
    [SerializeField]
    private int teamInfoNumber = 50;

    public Dictionary<GameObject, TeamInfo> teamInfos = new Dictionary<GameObject, TeamInfo>();

    private Queue<TeamInfo> teamInfoPool = new Queue<TeamInfo>();

    private void Awake()
    {
        for(int i = 0; i < teamInfoNumber; i++)
        {
            teamInfoPool.Enqueue(new TeamInfo());
        }
    }

    private void MakeTeamInfo(float multiple)
    {
        TeamInfo usingTeamInfo = teamInfoPool.Dequeue();
        //todo
    }

    private void RemoveTeamInfo(GameObject gameObject)
    {
        TeamInfo usedTeamInfo = teamInfos[gameObject];
        teamInfos.Remove(gameObject);

        teamInfoPool.Enqueue(usedTeamInfo);
    }
	
}
