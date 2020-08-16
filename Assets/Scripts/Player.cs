using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera;
    [Range(0, 1)]
    public float moveSpeed;
    public float mouseY;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            mouseY = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight - Input.GetTouch(0).position.y)).y;
        }

        if (Input.GetMouseButton(0))
        {
            FollowMouse(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        Move(new Vector2(0, Mathf.Clamp(mouseY - transform.position.y, -moveSpeed, moveSpeed)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"S");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            Debug.Log($"Hit! {collision.gameObject.name}");
    }

    private void Move(Vector3 dir)
    {
        transform.position += dir;
    }

    private void FollowMouse(Vector2 mouse)
    {
        Vector2 worldMouse = mainCamera.ScreenToWorldPoint(mouse);
        mouseY = worldMouse.y;
    }
}