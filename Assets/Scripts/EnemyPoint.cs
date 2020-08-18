using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : Enemy
{
    public GameObject movePrefab;
    public float speed;
    public float gravity;
    public float shootChance;

    private Vector2 playerDir;

    protected override void Awake()
    {
        base.Awake();

        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * speed;
    }

    protected override void FixedUpdate()
    {
        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * speed;

        base.FixedUpdate();

        playerDir = new Vector2(0, ((GameManager.instance.Player.transform.position - transform.position).normalized * gravity).y);

        Move(playerDir);

        if (Random.Range(0f, 100f) <= shootChance)
        {
            GameObject shot = Instantiate(movePrefab);
            shot.transform.position = transform.position;
            shot.GetComponent<EnemyMove>().SetDirection(playerDir);
        }
    }
}
