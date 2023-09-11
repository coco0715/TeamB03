using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    //Stage stage                  // Stage Ŭ���� �߰��� �ּ� ����

    // ��ȯ ����
    private int _GenCoeff
    {
        get { return _GenCoeff; }
        set { GenCoeff = value; }
    }
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
