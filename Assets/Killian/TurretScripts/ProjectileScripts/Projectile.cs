using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float trackingTime = 10f;
    public int damage;
    public float aoeRadius;
    public int path;
    public int chain;


    protected float lifetime;
    private Vector3 lastKnownPosition;

    protected virtual void Start()
    {
        lifetime = trackingTime;
        Tower tower = GetComponentInParent<Tower>();
        if (tower != null)
        {
            //inherit stats from original tower
            aoeRadius = tower.Area;
            path = tower.Path;
            chain = tower.Chain;
        }
        if (target != null)
        {
            /*log last known enemy location (this will be useful in large crowds)
             * if a tower shoots and the enemy dies before the projectile reaches them
             * it will continue to last known location, giving a chance to hit another enemy*/
            lastKnownPosition = target.position;
        }
    }

    private void Update()
    {
        if (target != null && lifetime > 0)
        {
            lastKnownPosition = target.position;

            Vector3 direction = (target.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

            lifetime -= Time.deltaTime;
        }
        else if (lifetime > 0) // Move towards last known position if target is null
        {
            MoveTowards(lastKnownPosition);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void MoveTowards(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Check if the projectile has reached the last known position
        if (Vector3.Distance(transform.position, position) < 0.1f) // Small threshold
        {
            Destroy(gameObject);
            return;
        }

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        EnemyBase enemy = other.transform.GetComponent<EnemyBase>();

        if (other.transform.CompareTag("Enemy") && enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    public void Initialize(Transform target, int damageValue)
    {
        this.target = target;
        this.damage = damageValue;
    }
}