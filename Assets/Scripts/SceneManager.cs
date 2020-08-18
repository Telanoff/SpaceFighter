using TMPro;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static readonly string HIGHSCORE = "highscore", HARDHIGHSCORE = "hhighscore", MODE = "hmode";
    public static string CHIGHSCORE;
    public TextMeshProUGUI highScoreTMP;

    private void Start()
    {
        ChangeMode(PlayerPrefs.GetInt(MODE));

        if (highScoreTMP != null)
        highScoreTMP.SetText($"High Score: {PlayerPrefs.GetInt(CHIGHSCORE)}");
    }

    public void ChangeScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

    public void ChangeMode(int newMode)
    {
        PlayerPrefs.SetInt(MODE, newMode);
        PlayerPrefs.Save();
        CHIGHSCORE = newMode == 0 ? HIGHSCORE : HARDHIGHSCORE;
    }

    public void ChangeSpawnMode(int mode)
    {
        PlayerPrefs.SetInt(EnemySpawner.MODE, mode);
        PlayerPrefs.Save();
    }
}