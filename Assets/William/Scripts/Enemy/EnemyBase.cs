using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyBase : MonoBehaviour
{
    //replace these with scriptableobject
    [SerializeField] private float healthPoints;
    [SerializeField] private int blood;
    [SerializeField] private float attackPower;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedSlowed;
    [SerializeField] private float atkSpeed;
    [SerializeField] private float stunTimer;
    [SerializeField] private float slowTimer;
    [SerializeField] private NavMeshAgent myAgent;


    private Coroutine slowedCoroutine = null;
    private Coroutine stunnedCoroutine = null;

    public void Start()
    {
        myAgent.speed = moveSpeed;
        myAgent.SetDestination(CastleScript.Instance.castleHurtbox.position);
    }
    public virtual void TakeDamage(int damage)
    {
        healthPoints = healthPoints - damage;

        Debug.Log($"Dealing {damage} to {this.name}");

        if (healthPoints <= 0)
        {
            ScoreManager.Instance.AddBlood(blood);

            Renderer renderer = GetComponentInChildren<Renderer>();
            Collider collider = GetComponent<Collider>();
            renderer.enabled = false;
            collider.enabled = false;
            Destroy(this.gameObject, 1); //gotta keep enemy alive for chain to work i guess, disable render and collider, then destroy after delay
        }
    }

    public void Slow()
    {
        if (slowedCoroutine != null)
        {
            StopCoroutine(slowedCoroutine);
        }
        slowedCoroutine = StartCoroutine(GetSlowed());
    }

    public IEnumerator GetSlowed()
    {
        //Debug.Log("slowed");
        myAgent.speed = moveSpeedSlowed;
        yield return new WaitForSeconds(slowTimer);

        Move();
    }

    protected virtual void Move()
    {
        if(slowedCoroutine == null && stunnedCoroutine == null)
        {
        myAgent.speed = moveSpeed;
        myAgent.SetDestination(CastleScript.Instance.castleHurtbox.position);
        }
    }

    protected IEnumerator Attack()
    {
        //play animation
        //Debug.Log("I attack, dmg: " + attackPower);
        CastleScript.Instance.TakeDamage(attackPower);
        yield return new WaitForSeconds(atkSpeed);
        StartCoroutine(Attack());
    }

    public void Stun()
    {
        if (stunnedCoroutine != null)
        {
            StopCoroutine(stunnedCoroutine);
        }
        stunnedCoroutine = StartCoroutine(GetStunned());
    }
    public IEnumerator GetStunned()
    {
        myAgent.speed = 0;
        yield return new WaitForSeconds(stunTimer);

        Move();
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("I got to the zone");
        StartCoroutine(Attack());
    }
}
