using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] towerPrefabs;

    public void BuildTower(SpawnableTowers tower, Transform playerTransform)
    {
        if (towerPrefabs == null || towerPrefabs.Length == 0)
        {
            Debug.LogWarning("Tower prefabs are not set.");
            return;
        }

        int towerIndex = (int)tower;

        if (towerIndex < 0 || towerIndex >= towerPrefabs.Length)
        {
            Debug.LogWarning("Invalid tower index: " + towerIndex);
            return;
        }

        GameObject towerPrefabObject = towerPrefabs[towerIndex];
        Tower towerInstance = Instantiate(towerPrefabObject, playerTransform.position, Quaternion.identity).GetComponent<Tower>();

        if (towerInstance == null)
        {
            Debug.LogWarning("Tower prefab does not have a Tower component.");
            return;
        }

        int currentBlood = ScoreManager.Instance.GetBlood();
        int towerCost = towerInstance.Cost;

        Debug.Log($"Current Blood: {currentBlood}, Tower Cost: {towerCost}");

        if (currentBlood >= towerCost)
        {
            ScoreManager.Instance.PayBlood(towerCost);
            Debug.Log("Spawned tower: " + tower);
        }
        else
        {
            Debug.LogWarning("Not enough blood to build the tower.");
            Destroy(towerInstance.gameObject);
        }
    }
}
