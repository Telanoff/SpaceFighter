using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public float PlayerSpeed;

    public UnityEvent Lose;

    private void Start()
    {
        Lose.AddListener(() =>
        {
            Debug.LogError("You Lost HaHaHaHaHa!!!!");
            #if UNITY_EDITOR
                EditorApplication.ExecuteMenuItem("Edit/Play");
            #else
                Application.Quit();
            #endif
        });
    }
}
