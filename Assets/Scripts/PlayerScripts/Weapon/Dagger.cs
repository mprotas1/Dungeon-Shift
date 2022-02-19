using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{
    //Chance to deal critical damage 
    private float criticalChance { get; set; }
    public Dagger(int damage, float chance)
    {
        this.Damage = damage;
        if(chance >= 1)
        {
            chance = 1;
        }
        if(chance <= 0)
        {
            chance = 0;
        }
        this.criticalChance = chance;
    }

    public bool isCritical()
    {
        if (Random.Range(0.0f, 1.0f) <= criticalChance)
        {
            return true;
        }
        else return false;
    }
}
