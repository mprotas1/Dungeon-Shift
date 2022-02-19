using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] maps;
    private SpawnMap spawnMap;

    private float xCoor = 0;
    private float zCoor = 0;

    public enum MapTypes
    {
        toNorth,
        toWest,
        toEast
    }

    /*
     * maps[0] = north
     * maps[1] = west
     * maps[2] = east
     */

    public void manageMaps(MapTypes mapTypes)
    {
        GameObject go;
        int randomNum;
        switch(mapTypes)
        {
            case MapTypes.toNorth:
                go = Instantiate(maps[Random.Range(0, maps.Length)]);
                xCoor -= 20;
                go.transform.position = new Vector3(xCoor, 0, zCoor);
                break;
            case MapTypes.toWest:
                randomNum = randomIntExcept(0, maps.Length, ((int)MapTypes.toEast));
                go = Instantiate(maps[randomNum]);
                spawnMap.currentMap = (MapTypes)randomNum;
                zCoor += 20;
                go.transform.position = new Vector3(xCoor, 0, zCoor);
                break;
            case MapTypes.toEast:
                randomNum = randomIntExcept(0, maps.Length, ((int)MapTypes.toWest));
                go = Instantiate(maps[randomNum]);
                spawnMap.currentMap = (MapTypes)randomNum;
                zCoor -= 20;
                go.transform.position = new Vector3(xCoor, 0, zCoor);
                break;
        }

    }

    private int randomIntExcept(int min, int max, int except)
    {
        int result = Random.Range(min, max - 1);
        if (result >= except) result += 1;
        return result;
    }
}
