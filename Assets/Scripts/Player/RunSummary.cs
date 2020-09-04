using TMPro;
using UnityEngine;

public class RunSummary : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI debrisTMP;
    public TextMeshProUGUI starDustTMP;

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void DisplayItems()
    {
        scoreTMP.SetText($"Score: {(int) GameManager.instance.Player.distance}");
        debrisTMP.SetText($"Debris: {GameManager.instance.DebrisCount}");
        starDustTMP.SetText($"Star Dust: {GameManager.instance.StarCount}");
    }
}