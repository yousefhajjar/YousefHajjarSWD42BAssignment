using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public static int damage = 0;
    
    int waveDamage = 0;

    public int GetDamage()
    {
        return damage;
    }

    //destroys the object
    public void Hit()
    {
        Destroy(gameObject);
    }
}
