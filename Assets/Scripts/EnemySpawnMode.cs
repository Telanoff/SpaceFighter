using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Spawn Mode")]
public class EnemySpawnMode : ScriptableObject
{
    public GameObject[] prefabs;
    public float[] chances;
    public float maxChance;
    public float chance;
    public int maxEnemies;

    public Vector2 spawnRange;
}
