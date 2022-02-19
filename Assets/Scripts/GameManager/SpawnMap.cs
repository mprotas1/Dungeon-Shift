using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnMap : MonoBehaviour
{
    private EnemyManagement enemyManagement;
    private MapManager mapManager;
    [SerializeField]
    public MapManager.MapTypes currentMap;
    void Start()
    {
        enemyManagement = GetComponent<EnemyManagement>();
        enemyManagement.AllEnemiesDied += MapSpawner;
        mapManager = GetComponent<MapManager>();
        currentMap = MapManager.MapTypes.toNorth;
    }

    private void MapSpawner()
    {
        Debug.Log("Instancjonujê mapê");
        mapManager.manageMaps(currentMap);
    }
}
