﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 1;
    
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
