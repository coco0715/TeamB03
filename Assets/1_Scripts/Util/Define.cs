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
        MainScene,
        GameScene,
        JiyeonScene,
        HalimScene
    }

    public enum Sound
    {
        Bgm,
        Effect,
        Speech,
        Max,
    }
}