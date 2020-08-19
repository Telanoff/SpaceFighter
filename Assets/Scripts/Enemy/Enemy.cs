using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector4 despawnPos;

    protected Vector2 dir;
    private bool dontCheck;
    private bool valid;

    protected virtual void FixedUpdate()
    {
        if (GameManager.instance.Paused)
            return;

        valid = true;
        if (!dontCheck)
            foreach (Collider2D collider in GetComponents<Collider2D>())
                if (collider.isTrigger)
                {
                    Destroy(collider);
                    dontCheck = true;
                }

        Move(new Vector2(-GameManager.instance.PlayerSpeed, 0));
        Move(dir);

        if (transform.position.x <= despawnPos.x || transform.position.x >= despawnPos.y || transform.position.y <= despawnPos.z || transform.position.y >= despawnPos.w)
            Destroy(gameObject);
    }

    protected void Move(Vector3 dir)
    {
        transform.position += dir;
    }

    protected virtual void Awake()
    {
        GameManager.instance.GetComponent<EnemySpawner>().enemies++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer && !valid)
            Destroy(gameObject);
    }

    protected virtual void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.MainCamera != null)
                GameManager.instance.MainCamera.transform.position = GameManager.instance.MainCameraDefaultPosition;
            GameManager.instance.GetComponent<EnemySpawner>().enemies--;
            if (GameManager.instance.GetComponent<EnemySpawner>().mode.chance < GameManager.instance.GetComponent<EnemySpawner>().mode.maxChance)
                GameManager.instance.GetComponent<EnemySpawner>().mode.chance += Time.deltaTime;
            if (GameManager.instance.PlayerSpeed < 1.14)
                GameManager.instance.PlayerSpeed += Time.deltaTime / 100;
        }
    }
}