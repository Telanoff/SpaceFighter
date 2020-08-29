using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStationary : Enemy
{
    public Vector4 sizeRange;
    public float size;
    public float speed;

    protected override void Awake()
    {
        base.Awake();

        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        size = Random.Range(sizeRange.x, sizeRange.y);
        transform.localScale = new Vector2(size, size);

        speed = Mathf.Lerp(sizeRange.z, sizeRange.w, Mathf.InverseLerp(sizeRange.x, sizeRange.y, size));
        dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * speed;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        transform.Rotate(new Vector3() { z = Random.value });
    }
}
