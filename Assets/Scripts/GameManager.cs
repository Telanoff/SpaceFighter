using UnityEngine;
using UnityEngine.Events;

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
            Application.Quit();
        });
    }
}
