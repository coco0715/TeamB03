using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterInformation
{
    [System.Serializable]
    public class Characters
    {
        public int Hp;
        public string Img;
        public float AttackSpeed;
        public float ProjectileSize;
        public float MoveSpeed;
    }

    [System.Serializable]
    public class CharacterData
    {
        public List<Characters> CharacterInfoList;
    }
}