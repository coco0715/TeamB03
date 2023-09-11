using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StageInformation
{
    [System.Serializable]
    public class Stage
    {
        int MaxScore;
        public bool IsLocked;
        public float EnemyGenCountCoeff;
        public float CoinGenCoeff;
        public float EnemySpeedCoeff;
        public float CoinSpeedCoeff;
        public float EnemyScaleCoeff;
        public float CoinScaleCoeff;
    }

    [System.Serializable]
    public class StageData
    {
        public List<Stage> StageInfoList;
    }
}