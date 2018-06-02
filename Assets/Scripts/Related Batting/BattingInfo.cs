using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattingInfo : MonoBehaviour
{
    public int battingPrice;

    public BattingInfo()
    {

    }

    public void Initialize(int battingPrice)
    {
        this.battingPrice = battingPrice;
    }
	
}
