using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnableEnemies
{
    NONE,
    KIDS,
    PARENTS,
    PITCHFORK,
    KNIGHT,
    BELMOND
};


[CreateAssetMenu(fileName = "EnemySpawnPattern", menuName = "ScriptableObjects/EnemySpawnPattern", order = 0)]
public class EnemySpawnPatternScriptableObject : ScriptableObject
{
    //[SerializeField] private List<SpawnableEnemies[]> spawnEnemyPatterns;
    [SerializeField] public ListWrapper<ListWrapper<SpawnableEnemies>> spawnEnemyPatterns;
}
