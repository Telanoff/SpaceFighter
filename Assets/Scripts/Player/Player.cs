using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static readonly string SPRITE = "playersprite", TYPE = "playertype";

    public AudioSource alert;
    public AudioSource die;
    public ParticleSystem falling;
    public TextMeshProUGUI distanceTMP;
    public GameObject[] sprites;
    [Range(0, 1)]
    public float moveSpeed;
    public float speed;
    public float maxSpeed;
    public float mouseY;
    public float distance;
    public bool isDead;

    private Rigidbody2D rb;
    private int clickFrames;
    private int releasedFrames;
    private bool tapped;

    private void Start()
    {
        sprites[PlayerPrefs.GetInt(SPRITE)].SetActive(true);

        rb = GetComponent<Rigidbody2D>();

        falling.Stop();

        alert.Stop();
        die.Stop();

        clickFrames = 3;
        releasedFrames = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            clickFrames++;
            if (tapped && releasedFrames < 3)
            {
                print("double press");
                releasedFrames = 0;
            }
            else if(!tapped && clickFrames + releasedFrames > 5)
            {
                FollowMouse(Input.mousePosition);
                releasedFrames = 0;
            }
        } else
        {
            if (clickFrames < 3)
            {
                tapped = true;
                clickFrames = 0;
            }
            if (tapped && releasedFrames < 3)
            {
                FollowMouse(Input.mousePosition);
                releasedFrames++;
            } else
            {
                tapped = false;
            }
        }
        /*if (Input.GetMouseButton(0))
        {
            FollowMouse(Input.mousePosition);
        }*/
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.Paused)
            return;

        if (isDead)
            rb.gravityScale = 1;
        else
        {
            distance += GameManager.instance.PlayerSpeed;
            distanceTMP.SetText($"Score: {(int) distance}");
            transform.rotation = Quaternion.identity;
            if (GameManager.instance.PlayerSpeed < maxSpeed)
                GameManager.instance.PlayerSpeed += Time.fixedDeltaTime / 1000;
            Move(new Vector2(0, Mathf.Clamp(mouseY - transform.position.y, -moveSpeed, moveSpeed)));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            isDead = true;

            alert.Play();

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