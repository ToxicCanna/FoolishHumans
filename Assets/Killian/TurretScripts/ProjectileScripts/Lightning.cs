using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Projectile
{
    public GameObject chainPrefab;


    private Vector3 hitLoc;

    protected override void Start()
    {
        base.Start();
        Tower tower = GetComponentInParent<Tower>();
        if (tower != null)
        {
            chain = tower.Chain;
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
         // Check if the projectile hits an enemy
        if (other.CompareTag("Enemy"))
        {
            EnemyBase enemy = other.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                if (path != 2)
                {
                    // Start the chain lightning effect
                    StartCoroutine(ChainLightning(other.transform, chain, new HashSet<EnemyBase>()));

                }
                else if (path == 2)
                {
                    LightningOrb(other.transform.position, aoeRadius);
                }
            }
            else
            {
                Debug.Log("enemy is null");
            }
        }

        // "Destroy" the projectile after hitting
        Renderer projectileRenderer = GetComponent<Renderer>();
        Collider projectileCollider = GetComponent<Collider>();

        if (projectileRenderer != null)
        {
            projectileRenderer.enabled = false; // Hide the projectile
        }

        if (projectileCollider != null)
        {
            projectileCollider.enabled = false; // Disable collider to prevent further interactions
        }
        //actually destroy projectile afer 2 secs
        Destroy(gameObject, 2f);
    }

    private IEnumerator ChainLightning(Transform target, int chainsLeft, HashSet<EnemyBase> hitEnemies)
    {
        if (target == null || chainsLeft <= 0)
            yield break;

        Debug.Log("chains left" + chainsLeft);

        EnemyBase enemy = target.GetComponent<EnemyBase>();
        if (enemy != null && !hitEnemies.Contains(enemy))
        {
            // Damage the enemy and record it

            hitLoc = enemy.transform.position;
            enemy.TakeDamage(damage);
            hitEnemies.Add(enemy);

            GameObject lightning = Instantiate(chainPrefab, hitLoc, Quaternion.identity);
            Destroy(lightning, .5f);
        }

        yield return new WaitForSeconds(0.1f);

        // Find the next enemy to chain to
        Transform nextTarget = FindClosestEnemy(hitLoc, hitEnemies);
        if (nextTarget != null)
        {
            yield return ChainLightning(nextTarget, chainsLeft - 1, hitEnemies); // Call again for the next target
            Debug.Log("Next Target" + nextTarget.name);
        }
        else
        {
            Debug.Log("No Target to chain to");
        }
    }

    private Transform FindClosestEnemy(Vector3 origin, HashSet<EnemyBase> hitEnemies)
    {
        Collider[] hitColliders = Physics.OverlapSphere(origin, aoeRadius);
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
    }

    private void LightningOrb(Vector3 targetPosition, float area)
    {
        GameObject lightning = Instantiate(chainPrefab, target.position, Quaternion.identity);

        float scaleFactor = area * 4;
        lightning.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

        hitLoc = targetPosition;

        Collider[] hitColliders = Physics.OverlapSphere(hitLoc, area);
        HashSet<EnemyBase> damagedEnemies = new HashSet<EnemyBase>();

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                EnemyBase enemy = hitCollider.GetComponent<EnemyBase>();
                if (enemy != null && !damagedEnemies.Contains(enemy))
                {
                    enemy.TakeDamage(damage);
                    damagedEnemies.Add(enemy);
                }
            }
        }

        Destroy(lightning, .5f);
    }
}
