using UnityEditor;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private void Start()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(0);
    }

    public void ChangeScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}