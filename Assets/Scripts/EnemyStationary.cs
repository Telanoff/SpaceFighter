using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStationary : Enemy
{
    public float speed;

    protected override void Awake()
    {
        base.Awake();

        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * speed;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        transform.Rotate(new Vector3() { z = Random.value });
    }
}
