using TMPro;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static readonly string HIGHSCORE = "highscore", HARDHIGHSCORE = "hhighscore", SAUCERHIGHSCORE = "shighscore", LIGHTNINGHIGHSCORE = "lhighscore", MODE = "hmode";
    public static readonly string[] HIGHSCORES = { HIGHSCORE, HARDHIGHSCORE, SAUCERHIGHSCORE, LIGHTNINGHIGHSCORE };
    public static string CHIGHSCORE;
    public TextMeshProUGUI highScoreTMP;
    public TMP_Dropdown modeDropdown;

    private void Start()
    {
        ChangeMode(PlayerPrefs.GetInt(MODE));

        if (highScoreTMP != null)
            highScoreTMP.SetText($"High Score: {PlayerPrefs.GetInt(CHIGHSCORE)}");
        if (modeDropdown != null)
            modeDropdown.value = PlayerPrefs.GetInt(MODE);
    }

    public void ChangeScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
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
}