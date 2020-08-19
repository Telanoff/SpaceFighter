using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    public static readonly string DEBRIS = "debris";

    private void FixedUpdate()
    {
        if (GameManager.instance.Paused)
            return;

        transform.position -= new Vector3(GameManager.instance.PlayerSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.DebrisCount++;
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.198f);
        }
        else if (collision.gameObject.CompareTag("Lazer"))
            Destroy(gameObject);
    }
}
