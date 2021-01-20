using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
            return;
        Explosion();
    }

    public void Explosion()
    {
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, 0.5f);
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
