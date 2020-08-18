using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Enemy
{
    public float speed;

    public void SetDirection(Vector2 newDir)
    {
        dir = newDir * speed;

        transform.rotation = Quaternion.Euler(0, 0, 180 + Mathf.Rad2Deg * Mathf.Atan2(newDir.y, newDir.x));
    }
}
