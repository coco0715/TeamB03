using NPCDatas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.U2D;

public class UI_Game : UI_Scene
{
    bool doneInit = false;
    List<NPCData> npcData = new List<NPCData>();

    enum GameObjects
    {
        OpenedSidePanel,
        Content,
    }
    enum Texts
    {
        TimeText,
    }
    enum Buttons
    {
        SettingCharacterButton,
        OpenButton,
        CloseButton,
        setBtn,
        startBtn,
        leaveBtn,
        inventoryBtn
    }

    void Start()
    {
        Init();
    }

    private void Update()
    {
        if(doneInit)
        {
            GetText((int)Texts.TimeText).text = DateTime.Now.ToString("HH:mm");
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.SettingCharacterButton).gameObject.BindEvent(OnClickedSettingButton);
        GetButton((int)Buttons.OpenButton).gameObject.BindEvent(OnClickedOpenButton);
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnClickedCloseButton);

        SetOpnedSidePanel();
        GetObject((int)GameObjects.OpenedSidePanel).SetActive(false);

        
        
        // Sound
        Managers.Sound.Clear();
        //Managers.Sound.Play("LobbyBgm", Define.Sound.Bgm);
        doneInit = true;
        return true;
    }

    public void SetOpnedSidePanel()
    {
        Transform[] childList = GetObject((int)GameObjects.Content).GetComponentsInChildren<Transform>();

        if(childList !=  null )
        {
            for(int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject); ;
            }
        }

        npcData = Managers.JsonReader.ReadNPCDataJson("Assets/Resources/Data/NPCData.json").NPCDataList;

        GameObject playerItem = Managers.UI.MakeSubItem<UI_InGameCharacter>(GetObject((int)GameObjects.Content).transform, "InGameCharacter").gameObject;
        UI_InGameCharacter player = playerItem.GetOrAddComponent<UI_InGameCharacter>();
        if (player.Init())
            player.SetInfo("Sprites/InGame/" + Managers.User.img, Managers.User.name);

        for (int i = 0; i < npcData.Count; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_InGameCharacter>(GetObject((int)GameObjects.Content).transform, "InGameCharacter").gameObject;
            UI_InGameCharacter character = item.GetOrAddComponent<UI_InGameCharacter>();
            if (character.Init())
                character.SetInfo(int.Parse(npcData[i].imgName), npcData[i].name);
        }
    }

    void OnClickedSettingButton()
    {
        Managers.UI.ShowPopupUI<UI_SettingCharacter>();
    }

    void OnClickedOpenButton()
    {
        GetObject((int)GameObjects.OpenedSidePanel).SetActive(true);
    }

    void OnClickedCloseButton()
    {
        GetObject((int)GameObjects.OpenedSidePanel).SetActive(false);
    }
}