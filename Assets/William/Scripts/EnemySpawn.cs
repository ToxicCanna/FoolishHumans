using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private EnemySpawnPatternScriptableObject spawnPattern;
    [SerializeField] private int[] delayBetweenSpawn;
    private int currentWave;

    public void SpawnEnemy(int waveNum)
    {
        if (spawnPattern.spawnEnemyPatterns.list.Count == delayBetweenSpawn.Length)
        {
            //Instantiate();
        }
    }
}
