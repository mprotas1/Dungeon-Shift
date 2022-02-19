using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinClass : PlayerCharacter
{

    public override event Action<int> HitPointsChanged;
    private float HolyChance { get; set; }

    private bool calculateHolyChance()
    {
        if(UnityEngine.Random.Range(0, 1) <= HolyChance)
        {
            return true;
        }
        return false;
    }

    public PaladinClass(PlayerData data)
    {
        ExperiencePoints = 0;
        CharacterLevel = 1;
        HitPoints = data.HitPoints;
        ManaPoints = data.ManaPoints;
        Armor = data.Armor;
        AttackRange = data.AttackRange;
        HolyChance = 0.1f;
        this.equipWeapon(new Sword(10, 0.1f));
    }
    public override void Attack(EnemyCharacter enemy)
    {
        enemy.ReceiveDamage(weapon.Damage);
        
    }

    public override void equipWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public override void ReceiveDamage(int damage)
    {
        if(calculateHolyChance())
        {
            HitPoints -= 0;
        }
        else
        {
            HitPoints -= (int)(damage + Armor);
            HitPointsChanged(HitPoints);
        }
    }
}
