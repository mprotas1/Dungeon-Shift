using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RogueClass : PlayerCharacter
{
    public override event Action<int> HitPointsChanged;
    private float evasion { get; set; }

    public RogueClass(PlayerData data)
    {
        ExperiencePoints = 0;
        CharacterLevel = 1;
        HitPoints = data.HitPoints;
        ManaPoints = data.ManaPoints;
        Armor = data.Armor;
        AttackRange = data.AttackRange;
        evasion = 0.1f;
        this.equipWeapon(new Dagger(10, 0.1f));
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
        bool evaded = false;
        if(UnityEngine.Random.Range(0.0f, 1.0f) <= evasion) {
            evaded = true;
        }
        if (evaded)
            HitPoints -= 0;
        else
        {
            HitPoints -= damage + Armor;

            HitPointsChanged(HitPoints);
        }
    }
}

