using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : Enemy
{
    public float speed;
    public float gravity;

    private Vector2 playerDir;

    protected override void Awake()
    {
        base.Awake();

        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * speed;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        playerDir = new Vector2(0, ((GameManager.instance.Player.transform.position - transform.position).normalized * gravity).y);

        Move(playerDir);
    }
}
