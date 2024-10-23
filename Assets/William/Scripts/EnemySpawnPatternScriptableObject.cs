using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnableEnemies
{
    NONE,
    FRANKENSTINEMONSTER,
    SKELETON
};


[CreateAssetMenu(fileName = "EnemySpawnPattern", menuName = "ScriptableObjects/EnemySpawnPattern", order = 0)]
public class EnemySpawnPatternScriptableObject : ScriptableObject
{
    //[SerializeField] private List<SpawnableEnemies[]> spawnEnemyPatterns;
    [SerializeField] private ListWrapper<ListWrapper<SpawnableEnemies>> spawnEnemyPatterns;
}
