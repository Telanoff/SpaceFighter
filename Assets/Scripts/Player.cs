using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource alert;
    public AudioSource die;
    public ParticleSystem falling;
    public TextMeshProUGUI distanceTMP;
    [Range(0, 1)]
    public float moveSpeed;
    public float mouseY;
    public bool isDead;

    private Rigidbody2D rb;
    private float distance;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        falling.Stop();

        alert.Stop();
        die.Stop();
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
        {
            distance += Time.fixedDeltaTime;
            distanceTMP.SetText($"Distance: {distance}");
            Move(new Vector2(0, Mathf.Clamp(mouseY - transform.position.y, -moveSpeed, moveSpeed)));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            isDead = true;

            alert.Play();
            alert.loop = true;

            die.Play();

            GameManager.instance.Lose.Invoke();
        }
    }

    private void Move(Vector3 dir)
    {
        transform.position += dir;
    }

    private void FollowMouse(Vector2 mouse)
    {
        Vector2 worldMouse = GameManager.instance.MainCamera.ScreenToWorldPoint(mouse);
        mouseY = worldMouse.y;
    }
}