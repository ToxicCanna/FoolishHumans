using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    //replace these with scriptableobject
    [SerializeField] private float healthPoints;
    [SerializeField] private float attackPower;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedSlowed;
    [SerializeField] private float atkSpeed;
    [SerializeField] private float stunTimer;
    [SerializeField] private float slowTimer;
    [SerializeField] private bool isMoving;
    [SerializeField] private NavMeshAgent myAgent;

    public void Start()
    {
        myAgent.speed = moveSpeed;
        myAgent.SetDestination(CastleScript.Instance.castleHurtbox.position);
    }
    public virtual void TakeDamage(int damage)
    {
        healthPoints = healthPoints - damage;

        Debug.Log("health" + healthPoints);

        if(healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public IEnumerator GetSlowed()
    {
        Debug.Log("slowed");
        myAgent.speed = moveSpeedSlowed;
        yield return new WaitForSeconds(slowTimer);
        Move();

    }

    protected virtual void Move()
    {
        isMoving = true;
        myAgent.speed = moveSpeed;
    }

    protected IEnumerator Attack()
    {
        //play animation
        Debug.Log("I attack, dmg: " + attackPower);
        CastleScript.Instance.TakeDamage(attackPower);
        yield return new WaitForSeconds(atkSpeed);
        StartCoroutine(Attack());
    }

    public IEnumerator GetStuned()
    {
        isMoving = false;
        myAgent.speed = 0;
        yield return new WaitForSeconds(stunTimer);
        Move();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("I got to the zone");
        StartCoroutine(Attack());
    }
}
