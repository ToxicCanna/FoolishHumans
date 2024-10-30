using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WebBlob : Projectile
{
    public float poisonDuration = 5f;
    public Color poisonColor = Color.green;

    protected override void Start()
    {
        base.Start();
        if (path == 2)
        {
            ChangeColor(poisonColor);
        }
    }

    protected override void OnTriggerEnter(Collider collision)
    {
        if (path != 2)
        {
            base.OnTriggerEnter(collision);
        }
        Destroy(gameObject);
        ApplyAoeEffect(collision.transform.position);
    }

    private void ApplyAoeEffect(Vector3 position)
    {
        // Find all colliders in the AoE radius
        Collider[] hitColliders = Physics.OverlapSphere(position, aoeRadius);
        foreach (var hitCollider in hitColliders)
        {
            EnemyBase enemy = hitCollider.GetComponent<EnemyBase>();
            if(enemy != null && hitCollider.CompareTag("Enemy"))
            {
                if (path == 2)
                {
                    //Debug.Log("Poison effect applied");
                    StartCoroutine(ApplyPoison(enemy));
                }
                else if (path == 1)
                {
                    //Debug.Log("getstunned is called");
                    enemy.Stun();
                }
                else
                {
                    //Debug.Log("getslowed is called");
                    enemy.Slow();
                }
            }
        }
    }

    private IEnumerator ApplyPoison(EnemyBase enemy)
    {
        float elapsed = 0f;

        // Store the original color of the enemy's materials
        Renderer[] enemyRenderers = enemy.GetComponentsInChildren<Renderer>();
        Color[] originalColors = new Color[enemyRenderers.Length];

        for (int i = 0; i < enemyRenderers.Length; i++)
        {
            originalColors[i] = enemyRenderers[i].material.color; // Store original color
            enemyRenderers[i].material.color = poisonColor;
        }

        while (elapsed < poisonDuration)
        {
            enemy.TakeDamage(damage); // Apply poison damage
            elapsed += 1f; // Adjust the interval for applying poison
            yield return new WaitForSeconds(1f); // Wait before applying the next damage
        }

        // Reset enemy color after poison duration
        for (int i = 0; i < enemyRenderers.Length; i++)
        {
            enemyRenderers[i].material.color = originalColors[i]; // Reset to original color
        }
    }

    private void ChangeColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color; // Change the projectile's color
        }
    }
}