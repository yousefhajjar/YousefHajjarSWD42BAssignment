﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShooting : MonoBehaviour
{

    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            EnemyFire();
            
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void EnemyFire()
    {

        GameObject enemyLaser = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
    }

}
