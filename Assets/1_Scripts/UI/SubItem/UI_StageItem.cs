using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageInformation;

public class UI_StageItem : UI_Base
{
    enum Images
    {
        UnlockedImage,
        LockedImage,
    }
    enum Texts
    {
        StageNumText,
        MaxScoreText,
    }

    public override bool Init()
    {

        if (base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));

        return true;
    }

    public void SetInfo(Stage stage, int stageNum)
    {
        if(stage.IsLocked)
        {
            GetImage((int)Images.LockedImage).gameObject.BindEvent(() => { Debug.Log("LockedStage"); });
        }
        else
        {
            GetText((int)Texts.StageNumText).text = (stageNum < 10) ? $"0{stageNum.ToString()}": stageNum.ToString();
            GetText((int)Texts.MaxScoreText).text = stage.MaxScore.ToString();
            GetImage((int)Images.LockedImage).gameObject.SetActive(false);

            GetImage((int)Images.UnlockedImage).gameObject.BindEvent(() =>
            {
                Managers.GameManager.StageNum = stageNum;
                Managers.Scene.ChangeScene(Define.Scene.MainGameScene);
            });
        }
    }
}
