using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI highScoreTMP;
    public TMP_Dropdown highScoreDropdown;
    public TextMeshProUGUI avgScoreTMP;
    public TMP_Dropdown avgScoreDropdown;
    public TextMeshProUGUI debrisTMP;
    public TextMeshProUGUI starTMP;
    public TextMeshProUGUI avgDebrisTMP;
    public TextMeshProUGUI avgStarTMP;
    public TextMeshProUGUI gamesPlayedTMP;

    private void Start()
    {
        highScoreTMP.SetText($"High Score: {PlayerPrefs.GetInt(SceneManager.CHIGHSCORE)}");
        highScoreDropdown.value = PlayerPrefs.GetInt(SceneManager.MODE);
        avgScoreTMP.SetText($"Average Score: {Scores.GetAverageScore()}");
        avgScoreDropdown.value = PlayerPrefs.GetInt(SceneManager.MODE);
        debrisTMP.SetText($"{PlayerPrefs.GetInt(Debris.DEBRIS)}");
        starTMP.SetText($"{PlayerPrefs.GetInt(StarDust.STARDUST)}");
        avgDebrisTMP.SetText($"Average {PlayerPrefs.GetInt(Debris.DEBRIS) / PlayerPrefs.GetInt(GameManager.GAMES_PLAYED)}");
        avgStarTMP.SetText($"Average {PlayerPrefs.GetInt(StarDust.STARDUST) / PlayerPrefs.GetInt(GameManager.GAMES_PLAYED)}");
        gamesPlayedTMP.SetText($"Games Played: {PlayerPrefs.GetInt(GameManager.GAMES_PLAYED)}");
    }
}
