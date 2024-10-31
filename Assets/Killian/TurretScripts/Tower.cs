using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TurretObject defaultData;
    public TurretObject path1;
    public TurretObject path2;
    public GameObject shotPrefab;

    public SpawnableTowers towerType;

    private bool canShoot;

    protected float atkSpd;
    protected int atkDmg;
    protected float range;
    protected float area;
    protected int chain;
    protected int level;
    protected int cost;
    protected int path;

    public float Area
    {
        get { return area; }
    }

    public int Chain
    {
        get { return chain; }
    }
    public int Path
    {
        get { return path; }
    }
    public int Cost
    {
        get { return cost; }
    }

    private void Awake()
    {
        InitializeTower(defaultData);
        canShoot = true;
    }

    private void Update()
    {
        if (canShoot)
        {
            Transform target = FindClosestEnemy();
            if (target != null)
            {
                Shoot(target);
            }
        }
    }
    private void InitializeTower(TurretObject data)
    {
        atkSpd = data.atkSpd;
        atkDmg = data.atkDmg;
        range = data.range;
        area = data.area;
        chain = data.chain;
        level = data.level;
        cost = data.cost;
    }

    private Transform FindClosestEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = hitCollider.transform;
                }
            }
        }
        return closestEnemy;
    }

    protected virtual IEnumerator ShotCooldown()
    {
        canShoot = false;

        var attackTime = 1 / (atkSpd / 50);
        yield return new WaitForSeconds(attackTime);

        canShoot = true;
    }

    protected virtual void Shoot(Transform target)
    {
        if (!canShoot) return;

        GameObject shot = Instantiate(shotPrefab, transform.position + new Vector3(0,(float)5.4,0), Quaternion.Euler(0,0,90), this.gameObject.transform);

        Projectile projectile = shot.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.Initialize(target, atkDmg);
        }

        StartCoroutine(ShotCooldown());
    }

    public virtual void Upgrade()
    {
        level++;
        cost = defaultData.cost * level;
        ScoreManager.Instance.PayBlood(cost);
    }

    public virtual void SetPath1()
    {
        InitializeTower(path1);
        path = 1;
        cost = path1.cost;
        ScoreManager.Instance.PayBlood(cost);
    }

    public virtual void SetPath2()
    {
        InitializeTower(path2);
        path = 2;
        cost = path2.cost;
        ScoreManager.Instance.PayBlood(cost);
    }

    public int GetLevel()
    {
        return level;
    }
}
