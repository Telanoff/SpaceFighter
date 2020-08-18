using UnityEngine;

public class DebrisGenerator : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 bounds;
    public float spawnX;
    public float chance;

    private void FixedUpdate()
    {
        if (Random.Range(0f, 100f) <= chance)
        {
            GameObject debris = Instantiate(prefab);
            debris.transform.position = new Vector3(spawnX, Random.Range(bounds.x, bounds.y));
        }
    }
}
