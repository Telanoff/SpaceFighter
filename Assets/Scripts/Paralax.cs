﻿using UnityEngine;

public class Paralax : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float startPos;
    private float dist;
    private float width;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        startPos = transform.position.x;
        width = sprite.bounds.size.x;
    }

    private void FixedUpdate()
    {
        dist -= GameManager.instance.PlayerSpeed * Time.fixedDeltaTime;
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (dist < startPos - width)
            dist += width;
    }
}
