using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MageClass : PlayerCharacter
{

    public override event Action<int> HitPointsChanged;
    private int MagicPower { get; set; }
    private int MagicProtection { get; set; }

    private Staff staff;

    public MageClass(PlayerData data)
    {
        ExperiencePoints = 0;
        CharacterLevel = 1;
        HitPoints = data.HitPoints;
        MaxHitPoints = HitPoints;
        ManaPoints = data.ManaPoints;
        Armor = data.Armor;
        AttackRange = data.AttackRange;
        MagicProtection = 5;
        MagicPower = 10;
        this.equipWeapon(new Staff(10));
    }
    public override void Attack(EnemyCharacter enemy)
    {
        //int dealtDamage = (int)(weapon.Damage + (weapon.Damage + (0.5 * MagicPower)));
        enemy.ReceiveDamage(weapon.Damage);
    }

    public override void equipWeapon(Weapon weapon)
    {
        this.weapon = staff;
    }

    public override void ReceiveDamage(int damage)
    {
        HitPoints -= (int) (damage + (Armor * (0.5 * MagicProtection)));

        HitPointsChanged(HitPoints);
    }
}
