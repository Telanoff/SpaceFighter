using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem falling;
    public Camera mainCamera;
    [Range(0, 1)]
    public float moveSpeed;
    public float mouseY;

    public bool isDead;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        falling.Stop();
    }

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
        if (isDead)
            rb.gravityScale = 1;
        else
            Move(new Vector2(0, Mathf.Clamp(mouseY - transform.position.y, -moveSpeed, moveSpeed)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            isDead = true;
            GameManager.instance.Lose.Invoke();
        }
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