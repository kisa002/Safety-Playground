using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSection : MonoBehaviour
{
    private BettingSection battingSection;
    [SerializeField]
    private GameObject settingSection;
    
    private void Awake()
    {
        battingSection = BettingSection.Instance;
    }

    public void ToBattingSection()
    {
        battingSection.On();
        settingSection.SetActive(false);
    }
    public void ToSettingSection()
    {
        battingSection.Off();
        settingSection.SetActive(true);
    }
}

