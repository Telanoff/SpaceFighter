﻿using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Player Player;
    public Camera MainCamera;
    public Vector3 MainCameraDefaultPosition;
    public float PlayerSpeed;
    public int DebrisCount;
    public int StarCount;
    public bool Paused;

    public UnityEvent Lose;

    public void DefaultLose()
    {
        Player.falling.Play();
        SaveAll();
    }

    public void GoToMenu()
    {
        StartCoroutine("GoToMenuCoroutine");
    }

    private IEnumerator GoToMenuCoroutine()
    {
        yield return new WaitForSeconds(1.69f);

        GetComponent<SceneManager>().ChangeScene(0);
        SaveAll();
    }

    private void OnDestroy()
    {
        SaveAll();
    }

    public void SaveAll()
    {
        if (Player != null)
        {
            if (Player.distance > PlayerPrefs.GetInt(SceneManager.CHIGHSCORE))
                PlayerPrefs.SetInt(SceneManager.CHIGHSCORE, (int)Player.distance);

            PlayerPrefs.SetInt(Debris.DEBRIS, PlayerPrefs.GetInt(Debris.DEBRIS) + DebrisCount);
            PlayerPrefs.SetInt(StarDust.STARDUST, PlayerPrefs.GetInt(StarDust.STARDUST) + StarCount);

            PlayerPrefs.Save();
        }
    }
}
