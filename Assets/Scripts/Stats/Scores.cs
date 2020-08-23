using TMPro;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_Dropdown dropdown;
    public string selScorePath;

    private void Awake()
    {
        ChangeSelHighScore(PlayerPrefs.GetInt(SceneManager.MODE));
    }

    public void ChangeSelHighScore(int index)
    {
        selScorePath = SceneManager.HIGHSCORES[index];
        scoreText.SetText($"{PlayerPrefs.GetInt(selScorePath)}");

        dropdown.value = index;
    }
}
