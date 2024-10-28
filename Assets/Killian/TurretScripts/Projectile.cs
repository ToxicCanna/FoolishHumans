using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float trackingTime = 10f;
    public int damage;

    private float lifetime;

    private void Start()
    {
        lifetime = trackingTime;
    }

    private void Update()
    {
        if (target != null && lifetime > 0)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
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