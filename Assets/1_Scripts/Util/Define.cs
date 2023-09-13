using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum UIEvent
    {
        Click,
        Pressed,
        PointerDown,
        PointerUp,
    }

    public enum Scene
    {
        Unknown,
        MainGameScene,
        LobbyScene,
        SelectStageScene,
        ResultScene,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        Speech,
        Max,
    }
}