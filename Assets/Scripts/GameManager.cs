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
        Player.falling.Play();

        if (Player.distance > PlayerPrefs.GetInt(SceneManager.CHIGHSCORE))
            PlayerPrefs.SetInt(SceneManager.CHIGHSCORE, (int) Player.distance);
        PlayerPrefs.Save();
    }

    public void GoToShop()
    {
        StartCoroutine("GoToShopCoroutine");
    }

    private IEnumerator GoToShopCoroutine()
    {
        yield return new WaitForSeconds(1.69f);

        GetComponent<SceneManager>().ChangeScene(1);
    }

    private void OnDestroy()
    {
        if (Player.distance > PlayerPrefs.GetInt(SceneManager.CHIGHSCORE))
            PlayerPrefs.SetInt(SceneManager.CHIGHSCORE, (int)Player.distance);
        PlayerPrefs.Save();
    }
}
