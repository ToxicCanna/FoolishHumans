using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Projectile
{
    public float area;
    public int chain;
    public GameObject lightningPrefab;

    /*protected override void Start()
    {
        lifetime = trackingTime;
        // Get the AoE radius from the parent Tower
        Tower tower = GetComponentInParent<Tower>();
        if (tower != null)
        {
            area = tower.Area; // Inherit area from the tower
            chain = tower.Chain; // inherit chain from tower
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        EnemyBase enemy = other.transform.GetComponent<EnemyBase>();

        if (other.transform.CompareTag("Enemy") && enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        StartCoroutine(ChainLightning(target, chain, new HashSet<EnemyBase>()));
    }

    private IEnumerator ChainLightning(Transform target, int chainsLeft, HashSet<EnemyBase> hitEnemies)
    {
        if (target == null || chainsLeft <= 0)
            yield break;

        EnemyBase enemy = target.GetComponent<EnemyBase>();
        if (enemy != null && !hitEnemies.Contains(enemy))
        {
            // Damage the enemy and record it
            enemy.TakeDamage(damage);
            hitEnemies.Add(enemy);
            Debug.Log($"Dealing {damage} to {target.name}");

            GameObject lightning = Instantiate(lightningPrefab, target.position, Quaternion.identity);
            Destroy(lightning, .5f);
        }

        yield return new WaitForSeconds(0.1f);

        // Find the next enemy to chain to
        Transform nextTarget = FindClosestEnemy(target.position, hitEnemies);
        if (nextTarget != null)
        {
            yield return ChainLightning(nextTarget, chainsLeft - 1, hitEnemies); // Call again for the next target
        }
        else
        {
            Debug.Log("help meh");
        }
    }

    private Transform FindClosestEnemy(Vector3 origin, HashSet<EnemyBase> hitEnemies)
    {
        Collider[] hitColliders = Physics.OverlapSphere(origin, area);
        Debug.Log($"Found {hitColliders.Length} colliders in range");

        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                EnemyBase enemy = hitCollider.GetComponent<EnemyBase>();
                if (enemy != null && !hitEnemies.Contains(enemy)) // Check if it has already been hit
                {
                    float distance = Vector3.Distance(origin, hitCollider.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = hitCollider.transform;
                    }
                }
            }
        }
        return closestEnemy;
    }*/
}
