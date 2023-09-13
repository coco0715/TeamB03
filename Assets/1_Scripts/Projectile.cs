using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageInformation;
public class Projectile : MonoBehaviour
{
    // 소환 갯수
    public int GenCoeff;
    public int GenCount;

    // 스피드

    public float SpeedCoeff;
    public float Speed;

    // Scale 및 Transform 콤프
    public float ScaleCoeff;
    public Vector3 _Scale;
    public Vector3 StartPosition;
    public Vector3 _Rotation;
    
    // 기타
    // public Color color;         // Color 가 필요한가.. 의문
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
