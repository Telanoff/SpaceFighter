using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static readonly string MODE = "spawnmode";

    public EnemySpawnMode[] modes;
    public EnemySpawnMode mode;
    public int enemies;

    private void Start()
    {
        try
        {
            mode = modes[PlayerPrefs.GetInt(MODE)];
        }
        catch (System.Exception e)
        { e.ToString(); }
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.Paused)
            return;

        if (enemies < mode.maxEnemies)
        {
            if (Random.Range(0f, 100f) > mode.chance * Mathf.Max((float) ((float) GameManager.instance.PlayerSpeed / 1.14), 0.5f))
                return;
            float r = Random.Range(0f, 100f);
            float lc = 0;

            for (int i = 0; i < mode.chances.Length; i++)
            {
                if (r <= mode.chances[i] + lc)
                {
                    Spawn(17, i);
                    break;
                }
                lc += mode.chances[i];
            }
        }
    }

    public GameObject Spawn(Vector2 position, int index)
    {
        GameObject enemy = Instantiate(mode.prefabs[index]);
        enemy.transform.position = position;
        return enemy;
    }

    public GameObject Spawn(float x, int index)
    {
        GameObject enemy = Spawn(new Vector2(x, Random.Range(mode.spawnRange.x, mode.spawnRange.y)), index);
        return enemy;
    }
}
