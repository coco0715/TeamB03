using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageInformation;
public class Projectile : MonoBehaviour
{
    // ��ȯ ����
    public int GenCoeff;
    public int GenCount;

    // ���ǵ�

    public float SpeedCoeff;
    public float Speed;

    // Scale �� Transform ����
    public float ScaleCoeff;
    public Vector3 _Scale;
    public Vector3 StartPosition;
    public Vector3 _Rotation;
    
    // ��Ÿ
    // public Color color;         // Color �� �ʿ��Ѱ�.. �ǹ�
    public Sprite sprite;
    public float TimeAccumulate;


    public void SetSpeed()
    {
        Speed *= SpeedCoeff;
    }

    public void SetScale()
    {
        _Scale = ScaleCoeff * new Vector3(1f, 1f, 1f);
    }

    public void SetCount()
    {
        GenCount = GenCoeff;
    }

    public void InitTime()
    {
        TimeAccumulate = 0f;
    }

    public Vector3 SetStartPosition()
    {
        float x = Random.Range(-2.7f, 2.7f);
        float y = 6f;
        StartPosition = new Vector3(x, y, 0);
        return StartPosition;
    }
}
