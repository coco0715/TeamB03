using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageInformation;
using ImageDatas;
using CharacterInformation;

public class GameManager : MonoBehaviour
{
    List<Stage> Stages = new List<Stage>();
    List<CharacterInformation.CharacterInfo> Characters = new List<CharacterInformation.CharacterInfo>();

    float Timer;
    int StageNum;

    public void Init()
    {
        Stages = Managers.JsonReader.ReadStageDataJson("Assets/Resources/Data/stageData.json").StageInfoList;
        Characters = Managers.JsonReader.ReadCharacterDataJson("Assets/Resources/Data/characterData.json").CharacterInfoList;
    }

    public void StartGame(int stageNum)
    {
        
    }

}
