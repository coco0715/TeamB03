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

    public float Timer;
    public int StageNum;

    public void Init()
    {
        Stages = Managers.JsonReader.ReadStageDataJson("Assets/Resources/Data/stageData.json").StageInfoList;
        Characters = Managers.JsonReader.ReadCharacterDataJson("Assets/Resources/Data/characterData.json").CharacterInfoList;
    }

    public void StartGame(int stageNum)
    {
        
    }

}
