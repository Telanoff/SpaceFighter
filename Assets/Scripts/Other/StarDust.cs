using UnityEngine;

public class StarDust : MonoBehaviour
{
    public static readonly string STARDUST = "stardust";
    public static GameObject Prefab;
    public static float Chance;
    public GameObject prefab;
    public float chance;

    private void Start()
    {
        if (Prefab == null)
            Prefab = prefab;
        if (Chance != chance)
            Chance = chance;
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.Paused)
            return;

        transform.position -= new Vector3(GameManager.instance.PlayerSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.StarCount++;
            Destroy(gameObject);
        }
    }

    public static void SpawnStarDust(Vector2 pos)
    {
        if (Random.Range(0f, 100f) <= Chance)
        {
            GameObject star = Instantiate(Prefab);
            star.transform.position = pos;
        }
    }
}
