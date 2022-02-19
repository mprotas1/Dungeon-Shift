using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCharacter : MonoBehaviour
{ 
    public int HitPoints { get; set; }
    public int Armor { get; set; }
    public int Damage { get; set; }
    public int ExpValue { get; set; }
    public abstract void ReceiveDamage(int damage);
    public abstract void Attack(PlayerCharacter player);
    public abstract void onDead();
}

