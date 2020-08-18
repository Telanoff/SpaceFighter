﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazer : Enemy
{
    public AudioSource lazerLoad;
    public AudioSource lazerShoot;

    public float spawnX;
    public float shake;
    public float chargeTime;
    public float fireTime;

    private bool shot;

    protected override void Awake()
    {
        base.Awake();

        GetComponentInChildren<ParticleSystem>().Play();
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;

        lazerShoot.Stop();
    }

    protected override void FixedUpdate()
    {
        if (shot)
        {
            GameManager.instance.MainCamera.transform.position = GameManager.instance.MainCameraDefaultPosition;
            GameManager.instance.MainCamera.transform.position += Random.insideUnitSphere * shake;
        }
    }

    private void Start()
    {
        transform.position = new Vector2(spawnX, GameManager.instance.Player.transform.position.y);

        GetComponentInChildren<ParticleSystem>().Play();
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;

        lazerLoad.Play();
        lazerLoad.loop = true;

        lazerShoot.Stop();

        StartCoroutine("Laser");
    }

    private IEnumerator Laser()
    {
        for (float t = 0; t <= 1; t++)
            yield return new WaitForSeconds(chargeTime);

        lazerLoad.Stop();
        shot = true;
        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponentInChildren<SpriteRenderer>().enabled = true;

        lazerShoot.Play();
        lazerShoot.loop = true;

        Destroy(gameObject, fireTime);
    }
}