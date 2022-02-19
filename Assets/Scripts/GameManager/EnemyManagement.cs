using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManagement : MonoBehaviour
{
    private List<GameObject> enemies;
    public event Action AllEnemiesDied;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex.Equals(2)) GetAllEnemies();    }

    public void GetAllEnemies()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        Debug.Log("Iloœæ: " + enemies.Count);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        Debug.Log("Pozosta³o1: " + enemies.Count);
        if (enemies.Count <= 0)
        {
            AllEnemiesDied();
            enemies.Clear();
            GetAllEnemies();
        }
        Debug.Log("Pozosta³o2: " + enemies.Count);
    }

}
