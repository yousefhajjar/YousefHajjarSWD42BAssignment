using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{

    int points = 0;

    [SerializeField] AudioClip playerPointSound;
    [SerializeField] [Range(0, 1)] float playerPointSoundVolume = 0.5f;
    
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Player P = otherObject.gameObject.GetComponent<Player>();

        Destroy(otherObject.gameObject);
        if (!otherObject.CompareTag("bullet"))
        {
            AudioSource.PlayClipAtPoint(playerPointSound, Camera.main.transform.position, playerPointSoundVolume);
            points += 5;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void Update()
    {
        print(points);
    }
}
