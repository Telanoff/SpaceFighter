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

        playerDir = (GameManager.instance.Player.transform.position - transform.position).normalized;

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
            shot.GetComponent<EnemyMove>().SetDirection(playerDir);
        }
    }

    private void OnDestroy()
    {
        alive = false;
    }
}
