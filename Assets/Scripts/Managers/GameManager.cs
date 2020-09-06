using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using System.Collections;
using System.IO;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public static string GAMES_PLAYED = "gamesplayed";

    public Player Player;
    public Camera MainCamera;
    public Vector3 MainCameraDefaultPosition;
    public float PlayerSpeed;
    public int DebrisCount;
    public int StarCount;
    public bool Paused;

    public UnityEvent Lose;

    private bool played;

    public void SaveGame()
    {
        Game game = new Game((int) Player.distance, DebrisCount, StarCount);

        DataUtil.Serialize(game, $"{PlayerPrefs.GetInt(GAMES_PLAYED) + 1}.game");
    }

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

            DebrisCount = 0;
            StarCount = 0;

            if (!played)
            {
                PlayerPrefs.SetInt(GAMES_PLAYED, PlayerPrefs.GetInt(GAMES_PLAYED) + 1);

                played = true;
            }

            PlayerPrefs.Save();
        }
    }
}
