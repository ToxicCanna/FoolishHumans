using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebBlob : Projectile
{
    public float aoeRadius; //set form the origin tower
    protected override void Start()
    {
        lifetime = trackingTime;
        // Get the AoE radius from the parent Tower
        Tower tower = GetComponentInParent<Tower>();
        if (tower != null)
        {
            aoeRadius = tower.Area; // Inherit area from the tower
        }
    }

    protected override void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);

        ApplyEffect(collision.transform);
        ApplyAoEEffect(collision.transform.position);
    }

    private void ApplyEffect(Transform target)
    {
        EnemyBase enemy = target.GetComponent<EnemyBase>();
        if (target.CompareTag("Enemy") && enemy != null)
        {
            enemy.TakeDamage(damage);
            StartCoroutine(enemy.GetSlowed());
        }
    }

    private void ApplyAoEEffect(Vector3 position)
    {
        // Find all colliders in the AoE radius
        Collider[] hitColliders = Physics.OverlapSphere(position, aoeRadius);
        foreach (var hitCollider in hitColliders)
        {
            EnemyBase enemy = hitCollider.GetComponent<EnemyBase>();
            if (enemy != null && hitCollider.CompareTag("Enemy"))
            {
                // Apply damage and slow to each enemy in range
                enemy.TakeDamage(damage);
                StartCoroutine(enemy.GetSlowed());
            }
        }
    }
}