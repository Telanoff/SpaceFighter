using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Type")]
public class EnemyType : ScriptableObject
{
    public float speed;
    public bool follow;
}