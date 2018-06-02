using System;
using UnityEngineInternal;

namespace SafetyPlay
{
    [Serializable]
    public class BettingGameInfo
    {
        public string name, res;
        public DateTime date;
        public float lose, win, draw;
        public int gid;
    }

    [Serializable]
    public class BettingInfo
    {
        public int bid, gid, _uid;
        public string win;
    }

    [Serializable]
    public class UserInfo
    {
        public int _uid;
        public string name;
        public int salary;
    }

    [Serializable]
    public class ResultData
    {
        public int ret;
    }
}