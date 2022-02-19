using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player data", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Parameters")]

    public string className;
    [Space(20)]
    [Range(0, 100)]
    public int HitPoints;

    [Range(0, 100)]
    public int ManaPoints;

    [Range(0, 50)]
    public int Armor;

    [Range(0, 10)]
    public float AttackRange;
}
