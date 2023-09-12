using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy EnemySet;

    private void Awake()
    {
    }

    public void SetDamage()
    {
        // ����Ƽ���� ���� ����ִ°� ������..
    }

    private void SummonEnemy()
    {
        EnemySet.SetEnemy();
        if (EnemySet != null)
        {
            Debug.Log($"Start Position : {EnemySet.StartPosition}");
            Debug.Log($"Speed : {EnemySet.Speed}");
            Instantiate(EnemySet);
        }
    }

    private void Start()
    {
        InvokeRepeating("SummonEnemy", 1f, 1f);
    }
}
