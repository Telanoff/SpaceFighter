using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector4 despawnPos;

    protected Vector2 dir;

    protected virtual void FixedUpdate()
    {
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

    private void OnDestroy()
    {
        if (GameManager.instance.MainCamera != null)
            GameManager.instance.MainCamera.transform.position = GameManager.instance.MainCameraDefaultPosition;
        GameManager.instance.GetComponent<EnemySpawner>().enemies--;
        if (GameManager.instance.GetComponent<EnemySpawner>().mode.chance < GameManager.instance.GetComponent<EnemySpawner>().mode.maxChance)
            GameManager.instance.GetComponent<EnemySpawner>().mode.chance += Time.deltaTime;
        if (GameManager.instance.PlayerSpeed < 1.14)
            GameManager.instance.PlayerSpeed += Time.deltaTime/10;
    }
}