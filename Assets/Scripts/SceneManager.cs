using TMPro;
using UnityEditor;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static int highScore;
    public TextMeshProUGUI highScoreTMP;

    private void Start()
    {
        if (!highScoreTMP)
            highScoreTMP.SetText($"High Score: {highScore}");
    }

    public void ChangeScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}