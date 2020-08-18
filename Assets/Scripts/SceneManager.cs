using TMPro;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static readonly string HIGHSCORE = "highscore", HARDHIGHSCORE = "hhighscore";
    public static readonly int NORMALMODE = 0, HARDMODE = 1;
    public static string CHIGHSCORE;
    public static int Mode;
    public TextMeshProUGUI highScoreTMP;

    private void Start()
    {
        ChangeMode(HARDMODE);

        if (highScoreTMP != null)
        highScoreTMP.SetText($"High Score: {PlayerPrefs.GetInt(CHIGHSCORE)}");
    }

    public void ChangeScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

    public void ChangeMode(int newMode)
    {
        Mode = newMode;
        CHIGHSCORE = Mode == NORMALMODE ? HIGHSCORE : HARDHIGHSCORE;
    }

    public void ChangeSpawnMode(int mode)
    {
        PlayerPrefs.SetInt(EnemySpawner.MODE, mode);
        PlayerPrefs.Save();
    }
}