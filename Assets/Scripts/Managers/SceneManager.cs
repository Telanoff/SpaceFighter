﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static readonly string POSTPROCESSING = "postprocessing",
        HIGHSCORE = "highscore", HARDHIGHSCORE = "hhighscore", SAUCERHIGHSCORE = "shighscore", LIGHTNINGHIGHSCORE = "lhighscore", METEORMODE = "mhighscore",
        MODE = "hmode";
    public static readonly string[] HIGHSCORES = { HIGHSCORE, HARDHIGHSCORE, SAUCERHIGHSCORE, LIGHTNINGHIGHSCORE, METEORMODE };
    public static string CHIGHSCORE;
    public UnityEvent onSceneChange;
    public Toggle ppt;
    public Camera mainCamera;

    public bool pp;

    private void Start()
    {
        ChangeMode(PlayerPrefs.GetInt(MODE));
        TogglePP(PlayerPrefs.GetInt(POSTPROCESSING) == 1);
    }

    public void ChangeScene(int index)
    {
        onSceneChange.Invoke();
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(index);
    }

    public void ChangeMode(int newMode)
    {
        PlayerPrefs.SetInt(MODE, newMode);
        PlayerPrefs.Save();
        CHIGHSCORE = HIGHSCORES[newMode];
    }

    public void ChangeSpawnMode(int mode)
    {
        PlayerPrefs.SetInt(EnemySpawner.MODE, mode);
        PlayerPrefs.Save();
    }

    public void TogglePP(bool value)
    {
        PlayerPrefs.SetInt(POSTPROCESSING, value ? 1 : 0);
        PlayerPrefs.Save();
        pp = value;
        PostProcessVolume ppv = mainCamera.GetComponent<PostProcessVolume>();
        ppv.enabled = value;

        if (ppt != null)
            ppt.isOn = value;
    }

    public void ChangePlayerType(int type)
    {
        PlayerPrefs.SetInt(Player.TYPE, type);
        PlayerPrefs.Save();
    }

    public void ChangePlayerSprite(int sprite)
    {
        PlayerPrefs.SetInt(Player.SPRITE, sprite);
        PlayerPrefs.Save();
    }
}