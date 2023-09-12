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
        //�Ѿ� �������
        Invoke("DestroyBullet", 10);
        M_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //�Ѿ� ������ ���� ��
        M_Rigidbody2D.velocity = Vector3.up * BulletSpeed;    
    }

    public void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBullet();
        //�� �״� �޼��� �߰� or ������ �߰�
    }
}
