using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Type")]
public class EnemyType : ScriptableObject
{
    public static readonly byte STATIONARY = 0, MOVING = 1, POINT = 2, LAZER = 3;

    public byte type;
    public float speed;
    public bool follow;
}