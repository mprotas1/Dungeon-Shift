using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    private float bleedChance { get; set; }
   
    public Sword(int damage, float chance)
    {
        this.Damage = damage;
        this.bleedChance = chance;
    }
}

