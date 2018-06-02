using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSection : MonoBehaviour
{
    private BattingSection battingSection;
    [SerializeField]
    private GameObject settingSection;
    
    private void Awake()
    {
        battingSection = BattingSection.Instance;
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

