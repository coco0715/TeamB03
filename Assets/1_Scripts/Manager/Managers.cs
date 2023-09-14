using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Managers : MonoBehaviour
{
    public static Managers s_instance = null;
    public static Managers Instance { get { return s_instance; } }

    private static GameManager s_gameManager = new GameManager();
    private static ResourceManager s_resourceManager = new ResourceManager();
    private static UIManager s_uiManager = new UIManager();
    private static SceneManagerEx s_SceneManager = new SceneManagerEx();
    private static SoundManager s_soundManager = new SoundManager();
    private static UserManager s_userManager = new UserManager();
    private static JsonReader s_jsonReader = new JsonReader();
    private static JsonWriter s_jsonWriter = new JsonWriter();
    //private static ObjectPoolManager s_objectPoolManager = new ObjectPoolManager();

    public static GameManager GameManager { get { Init(); return s_gameManager; } }
    public static ResourceManager Resource { get { Init(); return s_resourceManager; } }
    public static UIManager UI { get { Init(); return s_uiManager; } }
    public static SceneManagerEx Scene { get { Init(); return s_SceneManager; } }
    public static SoundManager Sound { get { Init(); return s_soundManager; } }
    public static UserManager User { get { return s_userManager; } }
    public static JsonReader JsonReader { get { return s_jsonReader; } }
    public static JsonWriter JsonWriter { get { return s_jsonWriter; } }
    //public static ObjectPoolManager ObjectPoolManager { get { Init();  return s_objectPoolManager; } }
    private void Start()
    {
        Init();
    }

    private static void Init()
    {
        //PlayerPrefs.DeleteAll();
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
                go = new GameObject { name = "@Managers" };

            s_instance = Utils.GetOrAddComponent<Managers>(go);

            DontDestroyOnLoad(go);

            //s_objectPoolManager.Init();
            s_gameManager.Init();
            s_resourceManager.Init();
            s_soundManager.Init();
            s_userManager.Init();

            Application.targetFrameRate = 60;
        }
    }
}