using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageInformation;
using ImageDatas;
using CharacterInformation;

public class GameManager : MonoBehaviour
{
    public List<Stage> Stages = new List<Stage>();
    public List<Characters> Characters = new List<Characters>();

    //public float Timer = 30f;
    public int StageNum;

    public void Init()
    {
        Stages = Managers.JsonReader.ReadStageDataJson("Assets/Resources/Data/stageData.json").StageInfoList;
        Characters = Managers.JsonReader.ReadCharacterDataJson("Assets/Resources/Data/characterData.json").CharacterInfoList;

        for(int i = 0; i < PlayerPrefs.GetInt("UnlockedStageNum", 1); i++)
        {
            Stages[i].IsLocked = false;
        }
    }

    /*void Update()
    {
        if(StartGame())
        {
            Timer -= Time.deltaTime;
        }
    }

    public bool StartGame()
    {
        if(Timer <= 0f)
        {
            return false;
        }
        return true;
    }*/
}
