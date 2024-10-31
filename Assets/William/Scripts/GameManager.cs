using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] towerPrefabs;
    public GameObject[] towers;

    public void BuildTower(SpawnableTowers tower)
    {
        
        
        towers = new GameObject[towerPrefabs.Length];

        for (int i = 0; i < towerPrefabs.Length; i++)
        {
            towers[i] = Instantiate(towerPrefabs[i]) as GameObject;
        }
        Debug.Log("I spawn" + tower);
    }
}
