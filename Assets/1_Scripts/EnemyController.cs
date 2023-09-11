using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyController : ProjectileController
{
    //Stage stage
    public int EnemySpeed;
    public EnemyController(Stage stage)
    {
        // GenCoeff = Stage.GenCountCoeff;
        // SpeedCoeff = Stage.EnemySpeedCoeff;
        // ScaleCoeff = Stage.EnemyScaleCoeff;
        Speed = EnemySpeed;
    }

    public void SetEnemy()
    {
        SetSpeed();
        SetCount();
        SetScale();
    }
}
