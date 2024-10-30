using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Projectile
{
    public GameObject explosionPrefab;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Find all enemies in the area of effect
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, aoeRadius);

            HashSet<EnemyBase> damagedEnemies = new HashSet<EnemyBase>();

            foreach (var hitCollider in hitColliders)
            {
                EnemyBase enemy = hitCollider.GetComponent<EnemyBase>();
                if (enemy != null && !damagedEnemies.Contains(enemy))
                {
                    enemy.TakeDamage(damage);
                    damagedEnemies.Add(enemy);
                }
            }

            // Optionally, you can add a visual effect or sound here for the explosion
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            float scaleFactor = aoeRadius;
            explosion.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor)* 4;
            Destroy(explosion, .5f);

            Destroy(gameObject);
        }
    }
}
