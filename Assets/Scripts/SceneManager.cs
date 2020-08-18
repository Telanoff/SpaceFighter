using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static readonly string POSTPROCESSING = "postprocessing", HIGHSCORE = "highscore", HARDHIGHSCORE = "hhighscore", SAUCERHIGHSCORE = "shighscore", LIGHTNINGHIGHSCORE = "lhighscore", MODE = "hmode";
    public static readonly string[] HIGHSCORES = { HIGHSCORE, HARDHIGHSCORE, SAUCERHIGHSCORE, LIGHTNINGHIGHSCORE };
    public static string CHIGHSCORE;
    public TextMeshProUGUI highScoreTMP;
    public TextMeshProUGUI debrisTMP;
    public TextMeshProUGUI starTMP;
    public Toggle ppt;
    public TMP_Dropdown modeDropdown;
    public Camera mainCamera;

    public bool pp;

    private void Start()
    {
        ChangeMode(PlayerPrefs.GetInt(MODE));
        TogglePP(PlayerPrefs.GetInt(POSTPROCESSING) == 1);

        if (highScoreTMP != null)
            highScoreTMP.SetText($"High Score: {PlayerPrefs.GetInt(CHIGHSCORE)}");
        if (debrisTMP != null)
            debrisTMP.SetText($"{PlayerPrefs.GetInt(Debris.DEBRIS)}");
        if (starTMP != null)
            starTMP.SetText($"{PlayerPrefs.GetInt(StarDust.STARDUST)}");
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
}