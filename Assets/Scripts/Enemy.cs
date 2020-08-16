using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public float despawnPos;

    private void FixedUpdate()
    {
        Move(new Vector2(-GameManager.instance.PlayerSpeed, 0));
        Move(new Vector2(-type.speed, 0));

        if (transform.position.x <= despawnPos)
            Destroy(gameObject);
    }

    private void Move(Vector3 dir)
    {
        transform.position += dir;
    }

    private void Awake()
    {
        GameManager.instance.GetComponent<EnemySpawner>().enemies++;
    }

    private void OnDestroy()
    {
        GameManager.instance.GetComponent<EnemySpawner>().enemies--;
    }
}