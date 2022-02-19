using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Object data", menuName = "Data/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Parameters")]

    [Range(0, 100)]
    [SerializeField]
    public int HitPoints;

    [Range(0, 50)]
    [SerializeField]
    public int Armor;

    [Range(0, 50)]
    [SerializeField]
    public int Damage;

    [Range(0, 1000)]
    [SerializeField]
    public int ExpValue;
}
