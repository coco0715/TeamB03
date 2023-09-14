using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;
public class Bullet : MonoBehaviour
{
    private float BulletSpeed = 2;
    private Rigidbody2D M_Rigidbody2D;
    Vector2 rotatedDirectionVector;
    public GameObject BulletImage;
    public int Style = 0;
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
    void Start()
    {
        int idx = PlayerPrefs.GetInt("CharacterIdx");
        if (idx >= 0 && idx <= 3)
        {
            Style = 0;
        }
        else if (idx >= 4 && idx <= 7)
        {
            Style = 1;
        }
        else if (idx >= 8 && idx <= 11)
        {
            Style = 2;
        }
        else if (idx >= 12 && idx <= 5)
        {
            Style = 3;
        }
        if (Style == 2)
        {
            BulletImage.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        SetArray();
        Debug.Log("!!!!!!! Style : " + Style);
        BulletImage.GetComponent<SpriteRenderer>().sprite = BulletArray[Style].GetComponent<SpriteRenderer>().sprite;
        if (BulletArray[Style].GetComponent<Animator>().runtimeAnimatorController != null)
        {
            BulletImage.GetComponent<Animator>().runtimeAnimatorController = BulletArray[Style].GetComponent<Animator>().runtimeAnimatorController;
        }
        //총알 사라지게
        Invoke("DestroyBullet", 10);
        M_Rigidbody2D = GetComponent<Rigidbody2D>();
        Quaternion rotationQuaternion = Quaternion.AngleAxis(this.transform.rotation.eulerAngles.z, Vector3.forward);
        rotatedDirectionVector = rotationQuaternion * Vector2.up;
    }
    void Update()
    {
        //총알 앞으로 가게 함
        M_Rigidbody2D.velocity = rotatedDirectionVector * BulletSpeed;
    }
    public void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //DestroyBullet();
        //적 죽는 메서드 추가 or 적한테 추가
    }
}