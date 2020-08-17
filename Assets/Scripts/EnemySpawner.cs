using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float[] chances;
    public float chance;
    public Vector2 spawnRange;
    public int maxEnemies;
    public int enemies;

    private void FixedUpdate()
    {
        if (enemies < maxEnemies)
        {
            if (Random.Range(0f, 100f) > chance)
                return;
            float r = Random.Range(0f, 100f);
            float lc = 0;

            for (int i = 0; i < chances.Length; i++)
            {
                if (r <= chances[i] + lc)
                {
                    Spawn(15, i);
                    break;
                }
                lc += chances[i];
            }
        }
    }

    public void Spawn(Vector2 position, int index)
    {
        GameObject enemy = Instantiate(prefabs[index]);
        enemy.transform.position = position;
    }

    public void Spawn(float x, int index)
    {
        Spawn(new Vector2(x, Random.Range(spawnRange.x, spawnRange.y)), index);
    }
}
