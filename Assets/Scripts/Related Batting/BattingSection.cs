using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattingSection : Singleton<BattingSection>
{
    private ScrollManager scrollManager;

    private void Awake()
    {
        scrollManager = GameObject.Find("GameScrollPanel").GetComponent<ScrollManager>();

    }

    public void Off()
    {    
        gameObject.SetActive(false);
        scrollManager.Stop();
    }

    public void On()
    {     
        gameObject.SetActive(true);

        scrollManager.ToOrigin();
        scrollManager.Start();
    }

}
