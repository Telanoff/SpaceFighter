using TMPro;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static readonly string HIGHSCORE = "highscore", HARDHIGHSCORE = "hhighscore";
    public static readonly byte NORMALMODE = 0x00, HARDMODE = 0xAA;
    public static string CHIGHSCORE;
    public static byte Mode;
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

    public void ChangeMode(byte newMode)
    {
        Mode = newMode;
        CHIGHSCORE = Mode == NORMALMODE ? HIGHSCORE : HARDHIGHSCORE;
    }
}