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
        // 유니티에서 직접 집어넣는게 나은가..
    }

    private void SummonEnemy()
    {
        EnemySet.SetEnemy();
        if (EnemySet != null)
        {
            var enemyGo = ObjectPoolManager.instance.Pool.Get();
            Debug.Log($"Start Position : {EnemySet.StartPosition}");
            Debug.Log($"Speed : {EnemySet.Speed}");
            enemyGo.SetActive(true);
            enemyGo.transform.position = EnemySet.StartPosition;
        }
    }

    private void Start()
    {
        InvokeRepeating("SummonEnemy", 1f, 1f / EnemySet.Speed);
    }
}
