using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private float BulletSpeed = 2;
    private Rigidbody2D M_Rigidbody2D;
    Vector2 rotatedDirectionVector;
    void Start()
    {
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
