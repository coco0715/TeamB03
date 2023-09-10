using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCDatas
{
    [System.Serializable]
    public class NPCData
    {
        public string imgName;
        public string name;
        public string dialogue;
    }

    [System.Serializable]
    public class NPCInfo
    {
        public List<NPCData> NPCDataList;
    }
}
