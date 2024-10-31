using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapTower : Tower
{
    /// <summary>
    /// This Code Works on its own, and will call the lightning effect without projectiles. this was changed to use a projectile, but this can be used as backup.
    /// </summary>

    /*public GameObject lightningPrefab;
    public Vector3 HitLoc;

    protected override void Shoot(Transform target)
    {
        StartCoroutine(ChainLightning(target, chain, new HashSet<EnemyBase>()));
        StartCoroutine(ShotCooldown());
    }

    private IEnumerator ChainLightning(Transform target, int chainsLeft, HashSet<EnemyBase> hitEnemies)
    {
        if (target == null || chainsLeft <= 0)
            yield break;

        EnemyBase enemy = target.GetComponent<EnemyBase>();
        if (enemy != null && !hitEnemies.Contains(enemy))
        {
            // Damage the enemy and record it
            enemy.TakeDamage(atkDmg);
            hitEnemies.Add(enemy);
            Debug.Log($"Dealing {atkDmg} to {target.name}");

            GameObject lightning = Instantiate(lightningPrefab, target.position, Quaternion.identity);

            HitLoc = target.position;
            Destroy(lightning, .5f);
        }

        yield return new WaitForSeconds(0.1f);

        // Find the next enemy to chain to
        Transform nextTarget = FindClosestEnemy(HitLoc, hitEnemies);
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

    public override void Upgrade()
    {
        base.Upgrade();

        if (level == 2)
        {
            atkDmg += 2;
            atkSpd += 10;
            range += 5;
        }
    }
}
