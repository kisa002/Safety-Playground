
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;
using SafetyPlay;
using UnityEditor;
using UnityEngine.Networking;
using UnityRest;

class Api
{
    public Api api = new Api();

    private string url = "http://safetyplay.dothome.co.kr";
    
    private Api() {}

    // GET
    public BettingGameInfo[] getBettingGames()
    {
        WWW www = new WWW(url);
        BettingGameInfo[] bettingGameInfoes = JsonHelper.FromJson<BettingGameInfo>(www.text);
        return bettingGameInfoes;
    }
    
    public BettingGameInfo getBettingGame()
    {
        WWW www = new WWW(url);
        BettingGameInfo bettingGameInfo = JsonUtility.FromJson<BettingGameInfo>(www.text);
        return bettingGameInfo;
    }

    public UserInfo getUser(string name)
    {
        WWW www = new WWW(url);
        UserInfo userInfo = JsonUtility.FromJson<UserInfo>(www.text);
        return userInfo;
    }

    public int getMoney(string name)
    {
        return getUser(name).salary;
    }
    
    // POST

    public bool getResult(WWWForm form)
    {
        using (var www = UnityWebRequest.Post(url + "", form))
        {
            www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;

                string json = results.ToString();

                return JsonUtility.FromJson<ResultData>(json).ret == 1;
            }
        }

        return false;
    }
    
    public bool addMoney(string name, int amount)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("amount", amount);

        return getResult(form);
    }
    
    public bool reduceMoney(string name, int amount)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("amount", amount);

        return getResult(form);
    }
    
    // LOSE, DRAW, WIN
    public bool createBetting(int uid, int gid, int price, string win)
    {
        WWWForm form = new WWWForm();
        form.AddField("uid", uid);
        form.AddField("gid", gid);
        form.AddField("price", price);
        form.AddField("win", win);

        return getResult(form);
    }

    /// <summary>
    /// This method will call "Create Method"
    /// </summary>
    public bool createBettingGame(string name, float win, float draw, float lose, string date, string ret)
    {
        WWWForm form = new WWWForm();

        return getResult(form);
    }

    public bool createUser(string name, string amount)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("amount", amount);
        return getResult(form);
    }
}