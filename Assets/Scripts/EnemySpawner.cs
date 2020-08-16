using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Vector2 spawnRange;
    public float chance;
    public int maxEnemies;
    public int enemies;

    private void FixedUpdate()
    {
        if (enemies < maxEnemies)
            if (Random.value <= chance)
                Spawn(15);
    }

    public void Spawn(Vector2 position, int index)
    {
        GameObject enemy = Instantiate(prefabs[index]);
        enemy.transform.position = position;
    }

    public void Spawn(Vector2 position)
    {
        Spawn(position, Random.Range(0, prefabs.Length));
    }

    public void Spawn(float x)
    {
        Spawn(new Vector2(x, Random.Range(spawnRange.x, spawnRange.y)));
    }
}
