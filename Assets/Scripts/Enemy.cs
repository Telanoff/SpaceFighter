using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public Vector3 despawnPos;

    private Vector2 dir;

    private void FixedUpdate()
    {
        if (type.type != EnemyType.LAZER)
            Move(new Vector2(-GameManager.instance.PlayerSpeed, 0));

        if (type.type == EnemyType.POINT)
            dir = new Vector2(0, ((GameManager.instance.player.transform.position - transform.position).normalized * type.speed).y);
        Move(dir);

        if (type.type == EnemyType.STATIONARY)
            transform.Rotate(new Vector3() { z = Random.value });

        if (transform.position.x <= despawnPos.x || transform.position.y <= despawnPos.y || transform.position.y >= despawnPos.z)
            Destroy(gameObject);
    }

    private void Move(Vector3 dir)
    {
        transform.position += dir;
    }

    private void Awake()
    {
        GameManager.instance.GetComponent<EnemySpawner>().enemies++;

        if (type.type == EnemyType.STATIONARY)
        {
            float angle = Random.Range(-Mathf.PI, Mathf.PI);

            dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * type.speed;
        }
        else
            dir = new Vector2(-type.speed, 0);
    }

    private void Start()
    {
        if (type.type == EnemyType.LAZER)
        {
            transform.position = new Vector2(5, GameManager.instance.player.transform.position.y);

            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;

            StartCoroutine("Laser");
        }
    }

    private IEnumerator Laser()
    {
        for (float t = 0; t <= 1; t++)
            yield return new WaitForSeconds(1);

        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponentInChildren<SpriteRenderer>().enabled = true;

        Debug.Log("Destroying");
        Destroy(gameObject, 0.69f);
    }

    private void OnDestroy()
    {
        GameManager.instance.GetComponent<EnemySpawner>().enemies--;
    }
}