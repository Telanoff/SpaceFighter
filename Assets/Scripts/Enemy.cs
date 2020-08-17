using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public Vector3 despawnPos;

    private Vector2 dir;

    private void FixedUpdate()
    {
        Move(new Vector2(-GameManager.instance.PlayerSpeed, 0));

        if (type.type == EnemyType.POINT)
        {
            dir = new Vector2(0, ((GameManager.instance.player.transform.position - transform.position).normalized * type.speed).y);
        }
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

    private void OnDestroy()
    {
        GameManager.instance.GetComponent<EnemySpawner>().enemies--;
    }
}