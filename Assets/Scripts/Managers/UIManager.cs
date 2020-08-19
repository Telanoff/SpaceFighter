using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static readonly string SHOPTAB = "shoptab";

    public GameObject menu;
    public TextMeshProUGUI counter;
    public GameObject[] panels;

    private void Start()
    {
        if (panels.Length > 0)
        {
            ChangePanel(PlayerPrefs.GetInt(SHOPTAB));
        }
    }

    public void ChangePanel(int index)
    {
        panels[PlayerPrefs.GetInt(SHOPTAB)].SetActive(false);

        PlayerPrefs.SetInt(SHOPTAB, index);
        PlayerPrefs.Save();

        panels[PlayerPrefs.GetInt(SHOPTAB)].SetActive(true);
    }

    public void ShowMenu()
    {
        menu.SetActive(true);

        GameManager.instance.Paused = true;
    }

    public void HideMenu()
    {
        menu.SetActive(false);
        StartCoroutine("Resume");
    }

    private IEnumerator Resume()
    {
        counter.SetText("3");
        yield return new WaitForSeconds(1);

        counter.SetText("2");
        yield return new WaitForSeconds(1);

        counter.SetText("1");
        yield return new WaitForSeconds(1);

        counter.SetText("GO!");
        yield return new WaitForSeconds(0.69f);

        counter.SetText("");

        GameManager.instance.Paused = false;
    }
}
