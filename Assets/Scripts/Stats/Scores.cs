using TMPro;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TMP_Dropdown dropdown;
    public string selHighScorePath;
    public string selAvgScorePath;

    private void Awake()
    {
        ChangeSelHighScore(PlayerPrefs.GetInt(SceneManager.MODE));
    }

    public void ChangeSelHighScore(int index)
    {
        selHighScorePath = SceneManager.HIGHSCORES[index];
        highScoreText.SetText($"{PlayerPrefs.GetInt(selHighScorePath)}");

        dropdown.value = index;
    }

    public static int GetAverageScore()
    {
        int[] scores = new int[PlayerPrefs.GetInt(GameManager.GAMES_PLAYED)];
        int all = 0;
        foreach (int score in scores)
            all += score;

        return all / PlayerPrefs.GetInt(GameManager.GAMES_PLAYED);
    }

    public void ChangeSelAverageScore(int index)
    {

    }
}
