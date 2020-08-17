using UnityEngine;

public class SceneManager : MonoBehaviour
{
    #region Singleton

    public static SceneManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion


}