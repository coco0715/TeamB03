using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using System;
using System.Linq;
using StageInformation;

public class EnemyController : MonoBehaviour
{
    public Enemy EnemySet;
    public StageInformation.Stage Stage;
    public int StageNum;

    public int GenCount;
    public float Speed;
    public Vector3 Scale;

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

    public bool IsAlive = true;
    //
    int cnt = 0;
    //

    public void SetDamage()
    {
        // 유니티에서 직접 집어넣는게 나은가..
    }

    public void GetEnemyInfo()
    {
        GenCount = (int)Stage.EnemyGenCountCoeff;
        Speed = Stage.EnemySpeedCoeff * 1.5f;
        Scale = Stage.EnemyScaleCoeff * new Vector3(1f, 1f, 1f);
    }
    void SetDict()
    {
        if (stage1SpriteInfos != null && StageNum >= 0)
        {
            for (int i = 0; i < stage1SpriteInfos.Length; i++) // stage 숫자가 1보다 작거나 같다면의 조건 추가
            {
                Array.Resize(ref randEnemyArray, randEnemyArray.Length + 1);
                randEnemyArray[randEnemyArray.Length - 1] = stage1SpriteInfos[i].enemyPrefab;
                Array.Resize(ref damageArray, damageArray.Length + 1);
                damageArray[damageArray.Length - 1] = 1;
            }
        }
        if (stage2SpriteInfos != null && StageNum >= 1)
        {
            for (int i = 0; i < stage2SpriteInfos.Length; i++) // stage 숫자가 2보다 작거나 같다면의 조건 추가
            {
                Array.Resize(ref randEnemyArray, randEnemyArray.Length + 1);
                randEnemyArray[randEnemyArray.Length - 1] = stage2SpriteInfos[i].enemyPrefab;
                Array.Resize(ref damageArray, damageArray.Length + 1);
                damageArray[damageArray.Length - 1] = 2;       // stage별 데이지 변화 필요시 변경
            }
        }
        if (Stage3SpriteInfos != null && StageNum >= 2)
        { 
            for (int i = 0; i < Stage3SpriteInfos.Length; i++) // stage 숫자가 3보다 작거나 같다면의 조건 추가
            {
                Array.Resize(ref randEnemyArray, randEnemyArray.Length + 1);
                randEnemyArray[randEnemyArray.Length - 1] = Stage3SpriteInfos[i].enemyPrefab;
                Array.Resize(ref damageArray, damageArray.Length + 1);
                damageArray[damageArray.Length - 1] = 3;       // stage별 데이지 변화 필요시 변경
            }
        }
    }
    private void SummonEnemy()
    {
        EnemySet.SetEnemy();
       
        if (EnemySet != null)
        {
            var enemyGo = ObjectPoolManager.instance.Pool.Get();
            enemyGo.SetActive(true);
            enemyGo.transform.position = EnemySet.StartPosition;

            enemyGo.GetComponent<Enemy>().TimeAccumulate = 0f;

            // animator 적용
            int randNum = UnityEngine.Random.Range(0, randEnemyArray.Length);
            enemyGo.GetComponent<Animator>().runtimeAnimatorController = randEnemyArray[randNum].GetComponent<Animator>().runtimeAnimatorController;
            enemyGo.GetComponent<Enemy>().Damage = damageArray[randNum];
        }
    }

    private void Start()
    {
        Managers.GameManager.Init();
        StageNum = Managers.GameManager.StageNum;
        Stage = Managers.GameManager.Stages[Managers.GameManager.StageNum];
        SetDict();
        EnemySet.SetEnemy();
        //InvokeRepeating("SummonEnemy", 1f, 1f / EnemySet.GenCount);
        
        StartCoroutine(RandomHelp());
    }

    private void Update()
    {
        if (cnt > 15)         // 스테이지 정지 조건 지금은 임시로 cnt로 달아둠. Player.HP나 시간에 연동할 예정
        {
            Time.timeScale = 0;
        }
    }

    IEnumerator RandomGen()
    {
        // EnemySet 프리팹의 정보가 아닌, 게임매니저의 정보를 가져오게끔...
        // json을 파싱할 때, enemyController에 넣어둠..
        // 혹은 파싱해서 게임매니저의 변수로 갖고 있어야함.
        // 이후 enemycontroller에서 gameManager의 값을 참조....
        // 플레이 상황에서 프리팹에 정보를 넣거나 가져올수 없다.,
        // 필요한 데이터는 게임매니저에서....
        GetEnemyInfo();
        float[] SecondDivide = new float[GenCount + 1];
        for (int i = 0; i < GenCount; i++) 
        {
            float RandSecond = UnityEngine.Random.Range(0, 1f);
            SecondDivide[i] = RandSecond;
        }
        SecondDivide[GenCount] = 1f;
        SecondDivide = SecondDivide.OrderBy(second => second).ToArray();
        yield return new WaitForSeconds(SecondDivide[0]);
        for (int i = 1; i < GenCount; i++) 
        {
            SummonEnemy();
            yield return new WaitForSeconds(SecondDivide[i] - SecondDivide[i-1]);
        }
    }

    IEnumerator RandomHelp()
    {
        cnt += 1;
        if (cnt > 15)
        {
            IsAlive = false;
        }
        while (IsAlive)
        {
            yield return StartCoroutine(RandomGen());
            if (!IsAlive)
            {
                yield break;
            }
        }
    }
}
