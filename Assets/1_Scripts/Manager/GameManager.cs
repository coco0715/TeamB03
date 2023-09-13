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

    public int StageNum;
    public bool IsStartedTimer = false;

    public void Init()
    {
        Stages = Managers.JsonReader.ReadStageDataJson("Assets/Resources/Data/stageData.json").StageInfoList;
        Characters = Managers.JsonReader.ReadCharacterDataJson("Assets/Resources/Data/characterData.json").CharacterInfoList;

        for(int i = 0; i < PlayerPrefs.GetInt("UnlockedStageNum", 1); i++)
        {
            Stages[i].IsLocked = false;
            Stages[i].MaxScore = PlayerPrefs.GetInt($"Stage{i+1}MaxScore", 0);
        }
    }
}
