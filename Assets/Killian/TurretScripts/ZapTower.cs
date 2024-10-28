using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapTower : Tower
{
    public GameObject lightningPrefab;

    protected override void Shoot(Transform target)
    {
        StartCoroutine(ChainLightning(target, chain));
        StartCoroutine(ShotCooldown());
    }

    private IEnumerator ChainLightning(Transform target, int chainsLeft)
    {
        if (target == null || chainsLeft <= 0)
            yield break;

        GameObject lightning = Instantiate(lightningPrefab, target.position, Quaternion.identity);

        EnemyBase enemy = target.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.TakeDamage(atkDmg);
            Debug.Log($"Dealing {atkDmg} to {target.name}");
        }

        yield return new WaitForSeconds(0.1f);

        // Find the next enemy to chain to
        Transform nextTarget = FindClosestEnemy(target.position);
        if (nextTarget != null)
        {
            yield return ChainLightning(nextTarget, chainsLeft - 1);
        }

        Destroy(lightning);
    }

    private Transform FindClosestEnemy(Vector3 origin)
    {
        Collider[] hitColliders = Physics.OverlapSphere(origin, area);
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(origin, hitCollider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = hitCollider.transform;
                }
            }
        }
        return closestEnemy;
    }

    protected override void Upgrade()
    {
        base.Upgrade();

        if (level == 2)
        {

        }
    }
}
