using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Skeleton : Projectile // Inherit from Projectile
{
    public float wanderRadius = 5f;
    public float chaseRange = 20f;
    public float lifespan = 15f;
    public float damageInterval = 2.5f; // Time interval for damage application

    private Vector3 wanderDestination;
    private Coroutine damageCoroutine; // Reference to the damage coroutine
    private EnemyBase currentTarget;
    private float skeleSpeed = 5f;

    private int skeletonDamage;

    protected override void Start()
    {
        Tower tower = GetComponentInParent<Tower>();
        if (tower != null)
        {
            path = tower.Path;
            lifespan = (path == 1) ? 20f : (path == 2) ? 10f : 15f;
        }

        StartCoroutine(Wander());
        Destroy(gameObject, lifespan); // Destroy skeleton after its lifespan
        StartCoroutine(FindTarget());
    }

    public void SetDamage(int damageValue)
    {
        skeletonDamage = damageValue;
    }

    private void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= chaseRange)
            {
                ChaseTarget();
            }
            else
            {
                target = null; // Reset target if out of range
            }
        }
        else
        {
            MoveTowards(wanderDestination);
        }
    }

    private void ChaseTarget()
    {
        MoveTowards(target.position);
    }

    private void MoveTowards(Vector3 destination)
    {
        Vector3 direction = (destination - transform.position).normalized;
        direction.y = 0f;
        transform.position += direction * skeleSpeed * Time.deltaTime;
    }

    private IEnumerator Wander()
    {
        while (true)
        {
            if (target == null) // Only wander if there's no target
            {
                wanderDestination = transform.position + Random.insideUnitSphere * wanderRadius;
                wanderDestination.y = 0; // Keep the same height
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return null; // If there's a target, wait for the next frame
            }
        }
    }

    private IEnumerator FindTarget()
    {
        while (true)
        {
            if (target == null)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, chaseRange);
                foreach (var collider in hitColliders)
                {
                    if (collider.CompareTag("Enemy")) // Make sure to use the correct tag
                    {
                        target = collider.transform; // Set target to the first enemy found
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(1f); // Check for targets every second
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyBase enemy = other.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                if (currentTarget == null) // If no current target, set this one
                {
                    currentTarget = enemy; // Set the current target
                    if (damageCoroutine == null)
                    {
                        damageCoroutine = StartCoroutine(ApplyDamage()); // Start damage coroutine
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyBase enemy = other.GetComponent<EnemyBase>();
            if (enemy != null && enemy == currentTarget) // If exiting the current target
            {
                currentTarget = null; // Clear the target
                if (damageCoroutine != null)
                {
                    StopCoroutine(damageCoroutine); // Stop the damage coroutine
                    damageCoroutine = null;
                }
            }
        }
    }

    private IEnumerator ApplyDamage()
    {
        while (currentTarget != null)
        {
            currentTarget.TakeDamage(skeletonDamage); // Apply damage to the current target
            yield return new WaitForSeconds(damageInterval); // Wait before applying damage again
        }
        damageCoroutine = null; // Reset coroutine reference when done
    }
}
