﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : Enemy
{
    public GameObject movePrefab;
    public float speed;
    public float gravity;
    public float shootDelay;

    private Vector2 playerDir;
    private bool alive;

    protected override void Awake()
    {
        base.Awake();

        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * speed;

        alive = true;

        StartCoroutine("Shoot");
    }

    protected override void FixedUpdate()
    {
        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * speed;

        base.FixedUpdate();

        playerDir = new Vector2(0, ((GameManager.instance.Player.transform.position - transform.position).normalized * gravity).y);

        Move(playerDir);
    }

    private IEnumerator Shoot()
    {
        while (alive)
        {
            yield return new WaitForSeconds(shootDelay);

            GameObject shot = Instantiate(movePrefab);
            shot.transform.position = transform.position;
            shot.GetComponent<EnemyMove>().SetDirection(playerDir);
        }
    }

    private void OnDestroy()
    {
        alive = false;
    }
}
