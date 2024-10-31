using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] towerPrefabs;
    [SerializeField] private EnemySpawn[] enemySpawnPoints;

    [SerializeField] private float initialSpawnDelay;
    [SerializeField] private float delayBetweenWaves;
    private int _currentWave;
    [SerializeField] private int totalWaves;

    private void Start()
    {
        _currentWave = 0;
        StartCoroutine(InitSpawn());
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void BossDestroyed()
    {
        StartCoroutine(YouWin());
    }
    IEnumerator YouWin()
    {

        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("YouWinScreen");
    }
    IEnumerator InitSpawn()
    {
        yield return new WaitForSeconds(initialSpawnDelay);
        BroadcastSpawn();
        _currentWave = _currentWave + 1;
        if (_currentWave < totalWaves)
        {
            StartCoroutine(spawnWaves());
        }
    }
    IEnumerator spawnWaves()
    { 
        yield return new WaitForSeconds(delayBetweenWaves);
        BroadcastSpawn();
        _currentWave = _currentWave + 1;
        if (_currentWave < totalWaves)
        {
            StartCoroutine(spawnWaves());
        }
    }

    private void BroadcastSpawn()
    {
        for (int i = 0; i < enemySpawnPoints.Length; i++)
        {
            enemySpawnPoints[i].StartSpawning(_currentWave);
        }
    }

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
