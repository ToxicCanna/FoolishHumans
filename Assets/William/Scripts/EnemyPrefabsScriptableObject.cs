using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyPrefabs", menuName = "ScriptableObjects/EnemyPrefabs", order = 1)]
public class EnemyPrefabsScriptableObject : ScriptableObject
{
    [SerializeField] private GameObject[] enemyPrefabs;
}
