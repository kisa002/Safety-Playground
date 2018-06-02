using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamInfo
{
    public float multiple;
    public string teamName;


    public TeamInfo()
    {

    }

    public void Initiailize(float multiple, string teamName)
    {
        this.multiple = multiple;
        this.teamName = teamName;

    }
}
