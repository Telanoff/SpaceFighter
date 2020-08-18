using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Enemy
{
    public float speed;

    protected override void Awake()
    {
        base.Awake();

        dir = new Vector2(-type.speed, 0);
    }
}
