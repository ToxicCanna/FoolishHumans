using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private EnemySpawnPatternScriptableObject spawnPattern;
    [SerializeField] private EnemyPrefabsScriptableObject spawnPrefabs;
    [SerializeField] private int delayDefault;
    [SerializeField] private int[] delayBetweenSpawn;
    private int currentWave;



    public void StartSpawning(int waveNum)
    {
        StartCoroutine(SpawnEnemy(waveNum));
    }
    IEnumerator SpawnEnemy(int waveNum)
    {
        if (spawnPattern.spawnEnemyPatterns.list.Count == delayBetweenSpawn.Length)
        {
            for (int i = 0; i < spawnPattern.spawnEnemyPatterns.list[waveNum].list.Count; i++)
            {
                SpawnableEnemies whatToSpawn = spawnPattern.spawnEnemyPatterns.list[waveNum].list[i];
                if (whatToSpawn != SpawnableEnemies.NONE)
                {
                    Instantiate(spawnPrefabs.enemyPrefabs[(int)whatToSpawn], this.transform.position, Quaternion.identity);
                }
                yield return new WaitForSeconds(delayBetweenSpawn[i]);
            }
        }
        else
        {
            //use default if something went wrong. 
            Debug.Log("Using default units");
            for (int i = 0; i < spawnPattern.spawnEnemyPatterns.list[waveNum].list.Count; i++)
            {
                SpawnableEnemies whatToSpawn = spawnPattern.spawnEnemyPatterns.list[waveNum].list[i];
                if (whatToSpawn != SpawnableEnemies.NONE)
                {
                    Instantiate(spawnPrefabs.enemyPrefabs[(int)whatToSpawn], this.transform.position, Quaternion.identity);
                }
                yield return new WaitForSeconds(delayDefault);
            }
            
        }

        yield return new WaitForSeconds(1);
    }
}
