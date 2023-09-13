using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Result : UI_Scene
{
    enum Images
    {
        PlayerImage,
    }
    enum Texts
    {
        PlayerNameText,
        PlayerLevelText,
        ValueText,
        ResultText,
    }
    enum Buttons
    {
        SettingButton,
        RetryButton,
        NextLevelButton,
        LobbyButton,
    }

    void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.SettingButton).gameObject.BindEvent(OnClickedSettingButton);
        GetButton((int)Buttons.RetryButton).gameObject.BindEvent(OnClickedRetryButton);
        GetButton((int)Buttons.NextLevelButton).gameObject.BindEvent(OnClickedNextLevelButton);
        GetButton((int)Buttons.LobbyButton).gameObject.BindEvent(OnClickedLobbyButton);

        GetButton((int)Buttons.RetryButton).gameObject.SetActive(false);
        GetButton((int)Buttons.NextLevelButton).gameObject.SetActive(false);

        GetImage((int)Images.PlayerImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.characterInfo.Img);
        GetText((int)Texts.PlayerNameText).text = Managers.User.name;
        GetText((int)Texts.PlayerLevelText).text = (Managers.User.UnlockedStageNum < 9) ? $"Lv.0{Managers.User.UnlockedStageNum}" : $"Lv.{Managers.User.UnlockedStageNum}";
        GetText((int)Texts.ValueText).text = Managers.User.score.ToString();

        SetResult();
        return true;
    }

    void OnClickedSettingButton()
    {
        Managers.Scene.ChangeScene(Define.Scene.SelectStageScene);
    }

    void OnClickedRetryButton()
    {
        Managers.User.score = 0;
        Managers.User.Hp = Managers.User.characterInfo.Hp;
        Managers.GameManager.IsStartedTimer = false;
        Managers.Scene.ChangeScene(Define.Scene.MainGameScene);
    }

    void OnClickedNextLevelButton()
    {
        Managers.GameManager.StageNum++;
        Managers.User.score = 0;
        Managers.User.Hp = Managers.User.characterInfo.Hp;
        Managers.GameManager.IsStartedTimer = false;
        Managers.Scene.ChangeScene(Define.Scene.MainGameScene);
    }

    void OnClickedLobbyButton()
    {
        Managers.User.score = 0;
        Managers.User.Hp = Managers.User.characterInfo.Hp;
        Managers.GameManager.IsStartedTimer = false;
        Managers.Scene.ChangeScene(Define.Scene.LobbyScene);
    }

    void SetResult()
    {
        Managers.User.coin += Managers.User.score;
        PlayerPrefs.SetInt("Coin", Managers.User.coin);
        if (PlayerPrefs.GetInt($"Stage{Managers.GameManager.StageNum}MaxScore", 0) <= Managers.User.score)
        {
            PlayerPrefs.SetInt($"Stage{Managers.GameManager.StageNum}MaxScore", Managers.User.score);
        }
        if (Managers.GameManager.Stages[Managers.GameManager.StageNum-1].ClearScore <= Managers.User.score)
        {
            GetText((int)Texts.ResultText).text = "GAME WIN";
            GetButton((int)Buttons.NextLevelButton).gameObject.SetActive(true);
            PlayerPrefs.SetInt("UnlockedStageNum", ++Managers.User.UnlockedStageNum);
        }
        else
        {
            GetText((int)Texts.ResultText).text = "GAME OVER";
            GetButton((int)Buttons.RetryButton).gameObject.SetActive(true);
        }
    }
}
