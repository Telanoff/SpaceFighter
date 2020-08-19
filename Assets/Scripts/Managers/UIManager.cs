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

    public Button backButton;

    private void Start()
    {
        if (panels != null)
        {
            ChangePanel(PlayerPrefs.GetInt(SHOPTAB));
        }
    }

    private void FixedUpdate()
    {
        if (menu.activeInHierarchy && Input.GetMouseButtonUp(0))
            HideMenu();
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
        if (!menu.activeInHierarchy)
        {
            counter.SetText("3");
            yield return new WaitForSeconds(1);
        }

        if (!menu.activeInHierarchy)
        {
            counter.SetText("2");
            yield return new WaitForSeconds(1);
        }

        if (!menu.activeInHierarchy)
        {
            counter.SetText("1");
            yield return new WaitForSeconds(1);
        }

        if (!menu.activeInHierarchy)
        {
            counter.SetText("GO!");
            yield return new WaitForSeconds(0.69f);
        }

        counter.SetText("");

        if(!menu.activeInHierarchy)
            GameManager.instance.Paused = false;
    }
}
