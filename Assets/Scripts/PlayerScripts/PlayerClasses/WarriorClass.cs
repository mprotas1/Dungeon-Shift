using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WarriorClass : PlayerCharacter
{
    public override event Action<int> HitPointsChanged;

    public WarriorClass(PlayerData data)
    {
        HitPoints = data.HitPoints;
        MaxHitPoints = HitPoints;
        ManaPoints = data.ManaPoints;
        ExperiencePoints = 0;
        CharacterLevel = 1;
        Armor = data.Armor;
        AttackRange = data.AttackRange;
        this.equipWeapon(new Sword(10, 0.1f));
    }

    public override void Attack(EnemyCharacter target)
    {
        target.ReceiveDamage(weapon.Damage);
    }

    public override void ReceiveDamage(int damage)
    {
        HitPoints -= damage + Armor;
        HitPointsChanged(HitPoints);
    }

    public override void equipWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
}
