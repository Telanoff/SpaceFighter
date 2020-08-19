using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menu;
    public TextMeshProUGUI counter;

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
