﻿using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawnMode[] modes;
    public EnemySpawnMode mode;
    public int enemies;

    private void FixedUpdate()
    {
        if (enemies < mode.maxEnemies)
        {
            if (Random.Range(0f, 100f) > mode.chance)
                return;
            float r = Random.Range(0f, 100f);
            float lc = 0;

            for (int i = 0; i < mode.chances.Length; i++)
            {
                if (r <= mode.chances[i] + lc)
                {
                    Spawn(15, i);
                    break;
                }
                lc += mode.chances[i];
            }
        }
    }

    public void Spawn(Vector2 position, int index)
    {
        GameObject enemy = Instantiate(mode.prefabs[index]);
        enemy.transform.position = position;
    }

    public void Spawn(float x, int index)
    {
        Spawn(new Vector2(x, Random.Range(mode.spawnRange.x, mode.spawnRange.y)), index);
    }

    public void ChangeMode(int index)
    {
        mode = modes[index];
    }
}
