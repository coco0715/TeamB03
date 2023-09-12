using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using ImageDatas;
using NPCDatas;
using CharacterInformation;
using StageInformation;

public class JsonReader
{
    public ImageInfo ReadCharacterImageJson(string path)
    {
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<ImageInfo>(json);
    }

    public NPCInfo ReadNPCDataJson(string path)
    {
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<NPCInfo>(json);
    }

    public CharacterData ReadCharacterDataJson(string path)
    {
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<CharacterData>(json);
    }

    public StageData ReadStageDataJson(string path)
    {
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<StageData>(json);
    }
}
