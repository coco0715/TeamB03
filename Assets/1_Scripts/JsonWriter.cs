using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using ImageDatas;
using NPCDatas;
using CharacterInformation;
using StageInformation;

public class JsonWriter
{
    public void WriteCharacterDataJson(CharacterData characterData, string path)
    {
        string json = JsonUtility.ToJson(characterData);
        File.WriteAllText(path, json);
    }
}
