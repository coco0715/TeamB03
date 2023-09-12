using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using System;


public class EnemyController : MonoBehaviour
{
    public Enemy EnemySet;
    [Serializable]
    public class Stage1SpriteInfo
    {
        public string animatorName;
        public GameObject enemyPrefab;
    }
    [SerializeField] Stage1SpriteInfo[] stage1SpriteInfos;

    [Serializable]
    public class Stage2SpriteInfo
    {
        public string animatorName;
        public GameObject enemyPrefab;
    }
    [SerializeField] Stage2SpriteInfo[] stage2SpriteInfos;

    [Serializable]
    public class Stage3SpriteInfo
    {
        public string animatorName;
        public GameObject enemyPrefab;
    }
    [SerializeField] Stage3SpriteInfo[] Stage3SpriteInfos;

    public GameObject[] randEnemyArray = null;
    public int[] damageArray = null;

    public void SetDamage()
    {
        // ����Ƽ���� ���� ����ִ°� ������..
    }

    void SetDict()
    {
        if (stage1SpriteInfos != null) 
        {
            for (int i = 0; i < stage1SpriteInfos.Length; i++) // stage ���ڰ� 1���� �۰ų� ���ٸ��� ���� �߰�
            {
                Array.Resize(ref randEnemyArray, randEnemyArray.Length + 1);
                randEnemyArray[randEnemyArray.Length - 1] = stage1SpriteInfos[i].enemyPrefab;
                Array.Resize(ref damageArray, damageArray.Length + 1);
                damageArray[damageArray.Length - 1] = 1;
            }
            for (int i = 0; i < stage2SpriteInfos.Length; i++) // stage ���ڰ� 2���� �۰ų� ���ٸ��� ���� �߰�
            {
                Array.Resize(ref randEnemyArray, randEnemyArray.Length + 1);
                randEnemyArray[randEnemyArray.Length - 1] = stage2SpriteInfos[i].enemyPrefab;
                Array.Resize(ref damageArray, damageArray.Length + 1);
                damageArray[damageArray.Length - 1] = 2;       // stage�� ������ ��ȭ �ʿ�� ����
            }
            for (int i = 0; i < Stage3SpriteInfos.Length; i++) // stage ���ڰ� 3���� �۰ų� ���ٸ��� ���� �߰�
            {
                Array.Resize(ref randEnemyArray, randEnemyArray.Length + 1);
                randEnemyArray[randEnemyArray.Length - 1] = Stage3SpriteInfos[i].enemyPrefab;
                Array.Resize(ref damageArray, damageArray.Length + 1);
                damageArray[damageArray.Length - 1] = 3;       // stage�� ������ ��ȭ �ʿ�� ����
            }
        }
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

            // animator ����
            int randNum = UnityEngine.Random.Range(0, randEnemyArray.Length);
            Debug.Log($"randNum : {randNum} || stage1Length : {randEnemyArray.Length}");
            enemyGo.GetComponent<Animator>().runtimeAnimatorController = randEnemyArray[randNum].GetComponent<Animator>().runtimeAnimatorController;
            enemyGo.GetComponent<Enemy>().Damage = damageArray[randNum];
        }
    }

    private void Start()
    {
        SetDict();
        InvokeRepeating("SummonEnemy", 1f, 1f / EnemySet.GenCount);
    }
}
