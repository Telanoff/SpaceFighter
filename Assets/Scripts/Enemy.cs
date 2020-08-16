using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;

    private void FixedUpdate()
    {
        Move(new Vector2(-GameManager.instance.PlayerSpeed, 0));
        Move(new Vector2(-type.speed, 0));
    }

    private void Move(Vector3 dir)
    {
        transform.position += dir;
    }
}