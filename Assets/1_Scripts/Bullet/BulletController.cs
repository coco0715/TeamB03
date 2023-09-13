using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Serializable]
    public class BulletCollection
    {
        public string PrefabName;
        public GameObject BulletPrefab;
    }
    [SerializeField] BulletCollection[] BulletCollections;

    public GameObject[] BulletArray = null;
    
    public void SetArray()
    {
        for (int i = 0; i < BulletCollections.Length; i++)
        {
            Array.Resize(ref BulletArray, BulletArray.Length + 1);
            BulletArray[BulletArray.Length - 1] = BulletCollections[i].BulletPrefab;
        }
    }

    private void Start()
    {
        SetArray();
    }
}
