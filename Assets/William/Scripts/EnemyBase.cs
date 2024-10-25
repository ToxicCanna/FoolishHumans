using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private float healthPoints;
    [SerializeField] private float attackPower;
    protected virtual void TakeDamage()
    { }

    protected virtual void GetSlowed()
    { }

    protected virtual void Move()
    { }

    protected virtual void Attack()
    { }

    protected virtual void GetStuned()
    { }
}
