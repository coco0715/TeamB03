using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Halim : UI_Scene
{
    enum Images
    {
        PlayerImage,
    }
    enum Texts
    {
        NameText,
    }
    enum Buttons
    {
        EnterButton, startBtn, leaveBtn, setBtn, InventoryBtn
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

        RefreshUI();
        GetButton((int)Buttons.EnterButton).gameObject.BindEvent(OnClickedEnterButton);

        Managers.UI.ShowPopupUI<UI_SettingCharacter>();

        return true;
    }

    public void RefreshUI()
    {
        GetText((int)Texts.NameText).text = Managers.User.name;
        GetImage((int)Images.PlayerImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.img);
    }

    void OnClickedEnterButton()
    {
        Managers.Scene.ChangeScene(Define.Scene.GameScene);
    }

    //여기서부터 어하림이 추가한 버튼 실행 코드인데 다음 화면 이름이 안정해져 넣지 않았습니다 . 
    void OnClickedstartBtn()
    {
        Managers.Scene.ChangeScene(Define.Scene.GameScene);
    }

    void OnClickedleaveBtn()
    {
        Application.Quit();
    }

    void OnClickedsetBtn()
    {
        
    }

    void OnClickedInventoryBtn()
    {
        
    }
}