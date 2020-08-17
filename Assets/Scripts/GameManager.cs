using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Player Player;
    public Camera MainCamera;
    public Vector3 MainCameraDefaultPosition;
    public float PlayerSpeed;

    public UnityEvent Lose;

    public void DefaultLose()
    {
        Debug.LogError("You Lost HaHaHaHaHa!!!!");

        Player.falling.Play();
    }

    public void GoToShop()
    {
        StartCoroutine("GoToShopCoroutine");
    }

    private IEnumerator GoToShopCoroutine()
    {
        yield return new WaitForSeconds(1);

        GetComponent<SceneManager>().ChangeScene(1);
    }
}
