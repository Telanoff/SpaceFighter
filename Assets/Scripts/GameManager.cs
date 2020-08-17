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

    public Player player;
    public float PlayerSpeed;

    public UnityEvent Lose;

    public void DefaultLose()
    {
        Debug.LogError("You Lost HaHaHaHaHa!!!!");

        player.falling.Play();
    }
}
