﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] float padding = 2;

    [SerializeField] AudioClip playerCrashSound;
    [SerializeField] [Range(0, 1)] float playerCrashSoundVolume = 0.05f;

    [SerializeField] AudioClip gameOverSound;
    [SerializeField] [Range(0, 1)] float gameOverSoundVolume = 0.1f;

    [SerializeField] GameObject deathVFX;

    float xMin, xMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        print(health);
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * 8;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        transform.position = new Vector2(newXPos, -6.5f);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {

        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();

        ObstaclePathing obs = otherObject.gameObject.GetComponent<ObstaclePathing>();

        if (!dmg)
        {
            return;
        }

        if (!obs)
        {
            health -= dmg.GetDamage();
            ProcessHit();
        }
        else if (otherObject.CompareTag("cone"))
        {
            health -= dmg.GetDamage1();
            ProcessHit();
        }
        else if (otherObject.CompareTag("barrier"))
        {
            health -= dmg.GetDamage2();
            ProcessHit();
        }
        else if (otherObject.CompareTag("enemyCar"))
        {
            health -= dmg.GetDamage3();
            ProcessHit();
        }
        else if (otherObject.CompareTag("enemyTank"))
        {
            health -= dmg.GetDamage4();
            ProcessHit();
        }
        else if (otherObject.CompareTag("truck"))
        {
            health -= dmg.GetDamage5();
            ProcessHit();
        }

        AudioSource.PlayClipAtPoint(playerCrashSound, Camera.main.transform.position, playerCrashSoundVolume);
        Destroy(otherObject.gameObject);
    }

    private void ProcessHit()
    {
        
        if (health <= 0)
        {
            Die();
            FindObjectOfType<Level>().LoadGameOver();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position, gameOverSoundVolume);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, 0.5f);
    }

    public int GetHealth()
    {
        return health;
    }
}
