using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    int damage = 1;

    int damage1 = 1;
    int damage2 = 2;
    int damage3 = 3;
    int damage4 = 4;
    int damage5 = 5;
    
    int waveDamage = 0;


    public int GetDamage1()
    {
        return damage1;
    }
    
    public int GetDamage()
    {
        return damage;
    }

    public int GetDamage2()
    {
        return damage2;
    }

    public int GetDamage3()
    {
        return damage3;
    }

    public int GetDamage4()
    {
        return damage4;
    }

    public int GetDamage5()
    {
        return damage5;
    }

    //destroys the object
    public void Hit()
    {
        Destroy(gameObject);
    }

}
