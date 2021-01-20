using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{

    [SerializeField] AudioClip playerPointSound;
    [SerializeField] [Range(0, 1)] float playerPointSoundVolume = 0.5f;
    
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);
        if (!otherObject.CompareTag("bullet"))
        {
            AudioSource.PlayClipAtPoint(playerPointSound, Camera.main.transform.position, playerPointSoundVolume);
            FindObjectOfType<GameSession>().AddToScore(5);
            int score = FindObjectOfType<GameSession>().GetScore();
            int health = FindObjectOfType<Player>().GetHealth();

            if(score >= 100 && health >= 0)
            {
                FindObjectOfType<Level>().LoadWinScene();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void Update()
    {
    }
}
