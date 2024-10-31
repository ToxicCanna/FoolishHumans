using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelmontDestroyed : MonoBehaviour
{
    [SerializeField] private EnemyBase enemyBaseScript;
    [SerializeField] private float myHealth;

    private void FixedUpdate()
    {
        myHealth = enemyBaseScript.GetHealth();
    }
    void OnDestroy()
    {
        if (myHealth <= 0)
        {
            GameManager.Instance.BossDestroyed();
        }
    }
}
