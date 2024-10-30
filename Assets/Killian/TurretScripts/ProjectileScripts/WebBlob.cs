using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WebBlob : Projectile
{

    protected override void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);

        ApplyAoEEffect(collision.transform.position);
    }

    private void ApplyAoEEffect(Vector3 position)
    {
        // Find all colliders in the AoE radius
        Collider[] hitColliders = Physics.OverlapSphere(position, aoeRadius);
        foreach (var hitCollider in hitColliders)
        {
            EnemyBase enemy = hitCollider.GetComponent<EnemyBase>();
            if (enemy != null && hitCollider.CompareTag("Enemy") && path != 1)
            {
                Debug.Log("getslowed is called");
                // Apply slow to each enemy in range
                StartCoroutine(enemy.GetSlowed());
            }
            else if (enemy != null && hitCollider.CompareTag("Enemy") && path == 1)
            {
                Debug.Log("getstunned is called");
                StartCoroutine(enemy.GetStuned());
            }
        }
    }
}