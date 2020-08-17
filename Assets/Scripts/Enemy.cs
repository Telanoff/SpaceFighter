using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public Vector3 despawnPos;

    private Vector2 dir;
    private bool lzS;

    private void FixedUpdate()
    {
        if (type.type != EnemyType.LAZER)
            Move(new Vector2(-GameManager.instance.PlayerSpeed, 0));

        if (type.type == EnemyType.POINT)
            dir = new Vector2(0, ((GameManager.instance.Player.transform.position - transform.position).normalized * type.speed).y);
        Move(dir);

        if (type.type == EnemyType.STATIONARY)
            transform.Rotate(new Vector3() { z = Random.value });

        if (lzS)
        {
            GameManager.instance.MainCamera.transform.position = GameManager.instance.MainCameraDefaultPosition;
            GameManager.instance.MainCamera.transform.position += Random.insideUnitSphere * type.speed;
        }

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
        else if (type.type != EnemyType.LAZER)
            dir = new Vector2(-type.speed, 0);
    }

    private void Start()
    {
        if (type.type == EnemyType.LAZER)
        {
            transform.position = new Vector2(5, GameManager.instance.Player.transform.position.y);

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

        lzS = true;
        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponentInChildren<SpriteRenderer>().enabled = true;

        Destroy(gameObject, 1);
    }

    private void OnDestroy()
    {
        GameManager.instance.MainCamera.transform.position = GameManager.instance.MainCameraDefaultPosition;
        GameManager.instance.GetComponent<EnemySpawner>().enemies--;
    }
}