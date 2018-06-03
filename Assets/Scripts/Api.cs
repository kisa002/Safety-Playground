
using System;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;
using SafetyPlay;
using UnityEditor;
using UnityEngine.Networking;
using UnityRest;
using System.Collections;

public class Api
{

    private static string url = "http://safetyplay.dothome.co.kr";



    // GET
    public IEnumerator getBettingGames()
    {
        WWW www = new WWW(url + "/games");
        yield return www;

        BettingGameInfo[] bettingGameInfoes = JsonHelper.FromJson<BettingGameInfo>(www.text);
        

    }


    public BettingGameInfo getBettingGame(int gid)
    {
        WWW www = new WWW(url + "/game?gid="+gid);
        BettingGameInfo bettingGameInfo = JsonUtility.FromJson<BettingGameInfo>(www.text);
        return bettingGameInfo;
    }


    public UserInfo getUser(string name)
    {
        WWW www = new WWW(url+"/user?name="+name);
        UserInfo userInfo = JsonUtility.FromJson<UserInfo>(www.text);
        return userInfo;
    }

    public int getMoney(string name)
    {
        return getUser(name).salary;
    }
    
    // POST

    public static bool getResult(string path, WWWForm form)
    {
        using (var www = UnityWebRequest.Post(url + path, form))
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


    public static bool addMoney(string name, int amount)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("amount", amount);

        return getResult("/add/money", form);
    }


    public static bool reduceMoney(string name, int amount)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("amount", amount);

        return getResult("/reduce/money", form);
    }


    // LOSE, DRAW, WIN
    public static bool createBetting(int uid, int gid, int price, string win)
    {
        WWWForm form = new WWWForm();
        form.AddField("uid", uid);
        form.AddField("gid", gid);
        form.AddField("price", price);
        form.AddField("win", win);

        return getResult("/create/bet", form);
    }

    public static bool createBettingGame(string name, float win, float draw, float lose, string date, string ret)
    {
        WWWForm form = new WWWForm();

        return getResult("/create/game", form);
    }

    public static bool createUser(string name, string amount)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("amount", amount);
        return getResult("/create/user", form);
    }



}