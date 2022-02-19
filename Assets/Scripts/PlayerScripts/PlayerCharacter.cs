using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCharacter
{
    public int HitPoints { get; set; }
    public int MaxHitPoints { get; set; }
    public int ManaPoints { get; set; }
    public int ExperiencePoints { get; set; }
    public int CharacterLevel { get; set; }
    public int Armor { get; set; }
    public float AttackRange { get; set; }

    public Weapon weapon;
    public abstract void ReceiveDamage(int damage);
    public abstract void Attack(EnemyCharacter enemy);
    public abstract void equipWeapon(Weapon weapon);

    public abstract event Action<int> HitPointsChanged;
}
