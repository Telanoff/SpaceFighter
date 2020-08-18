using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Enemy
{
    public float speed;

    public void SetDirection(Vector2 newDir)
    {
        dir = newDir * speed;
    }
}
