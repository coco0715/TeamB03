using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    //Stage stage                  // Stage 클래스 추가시 주석 해제

    // 소환 갯수
    private int _GenCoeff
    {
        get { return _GenCoeff; }
        set { GenCoeff = value; }
    }
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

    public void SetStartPosition()
    {

    }

    public void SetRotation()
    {
        
    }

}
