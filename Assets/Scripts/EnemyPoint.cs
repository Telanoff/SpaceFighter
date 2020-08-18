using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : Enemy
{
    public GameObject movePrefab;
    public Vector2 spawnOffset;
    public float speed;
    public float gravity;
    public float shootDelay;

    private Vector2 playerDir;
    private float angle;
    private bool alive;

    protected override void Awake()
    {
        base.Awake();

        angle = Random.Range(-Mathf.PI, Mathf.PI);

        dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * speed;

        alive = true;

        StartCoroutine("Shoot");
    }

    protected override void FixedUpdate()
    {
        angle += Mathf.Deg2Rad;
        dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * speed;

        base.FixedUpdate();

        playerDir = (GameManager.instance.Player.transform.position - transform.position).normalized * gravity;

        Move(playerDir);
    }

    private IEnumerator Shoot()
    {
        while (alive)
        {
            yield return new WaitForSeconds(shootDelay);

            GameObject shot = Instantiate(movePrefab);
            shot.transform.position = transform.position;
            shot.transform.position += (Vector3) spawnOffset;
            Vector2 nPlayerDir = playerDir / gravity;
            float ang = Mathf.Clamp(Mathf.Atan2(nPlayerDir.y, nPlayerDir.x), -45, 45) * Mathf.Deg2Rad;
            shot.GetComponent<EnemyMove>().SetDirection(new Vector2(Mathf.Sin(ang), Mathf.Cos(ang)));
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        alive = false;
    }
}
