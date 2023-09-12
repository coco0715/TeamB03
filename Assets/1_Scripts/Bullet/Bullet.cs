using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float BulletSpeed;
    private Rigidbody2D M_Rigidbody2D;
    void Start()
    {
        //총알 사라지게
        Invoke("DestroyBullet", 10);
        M_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //총알 앞으로 가게 함
        M_Rigidbody2D.velocity = Vector3.up * BulletSpeed;    
    }

    public void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBullet();
        //적 죽는 메서드 추가 or 적한테 추가
    }
}
