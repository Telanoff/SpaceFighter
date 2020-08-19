using UnityEngine;

public class DebrisGenerator : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 bounds;
    public float spawnX;
    public float maxChance;
    public float chance;

    private void FixedUpdate()
    {
        if (GameManager.instance.Paused)
            return;

        if (Random.Range(0f, 100f) <= chance * Mathf.Max((float)((float)GameManager.instance.PlayerSpeed / 1.14), 0.3f))
        {
            GameObject debris = Instantiate(prefab);
            debris.transform.position = new Vector3(spawnX, Random.Range(bounds.x, bounds.y));

            if (chance < maxChance)
                chance += Time.deltaTime / 5;
        }
    }
}
