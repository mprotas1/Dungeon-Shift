using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : EnemyCharacter
{
    [SerializeField]
    private EnemyData[] enemyDatas;

    public event Action<float> HealthChanged;

    private float maxHP;
    private LevelManager levelManager;
    private EnemyManagement enemyManagement;
    
    private void Start()
    {
        InitializeEnemy(1);
        levelManager = GameObject.Find("Player").GetComponent<LevelManager>();
        enemyManagement = GameObject.Find("GameManager").GetComponent<EnemyManagement>();
    }

    // 'level' is parameter delivered by GameManager that depends on which level player is currently
    public void InitializeEnemy(int level)
    {
        EnemyData enemyData = enemyDatas[UnityEngine.Random.Range(0, enemyDatas.Length)];
        HitPoints = enemyData.HitPoints * level;
        Damage = enemyData.Damage + (int) 0.5 * level;
        Armor = enemyData.Armor;
        ExpValue = enemyData.ExpValue;
        maxHP = HitPoints;
    }

    public override void ReceiveDamage(int damage)
    {
        HitPoints -= damage + Armor;
        float currentHealth = (float) HitPoints / (float) maxHP;
        HealthChanged(currentHealth);
        onDead();
    }

    public bool isDead()
    {
        if (this.HitPoints <= 0)
        {
            return true;
        }
        return false;
    }

    public override void Attack(PlayerCharacter player)
    {
        player.ReceiveDamage(Damage);
    }


    // TU ODWO£UJÊ SIÊ DO enemyManagement
    public override void onDead()
    {
        if (isDead())
        {
            Destroy(gameObject);
            levelManager.AddExp(ExpValue);
            enemyManagement.RemoveEnemy(gameObject);
        }
    }
}
