using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int krw = 50000;
    public string username = "username";

    private void Awake()
    {
        if (GameManager.Instance == null)
            GameManager.Instance = this;
        else
            Destroy(this.gameObject);
    }
}
