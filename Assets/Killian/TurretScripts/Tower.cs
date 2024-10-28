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

    private bool canShoot;

    protected float atkSpd;
    protected float atkDmg;
    protected float range;
    protected float area;
    protected float chain;
    protected int level;
    protected int cost;

    public GameObject upgradePanel;

    private void Awake()
    {
        InitializeTower(defaultData);
        canShoot = true;
    }

    public void Start()
    {
        var attackTime = 1 / (atkSpd / 50f);
        Debug.Log(attackTime);
    }

    private void Update()
    {
        if (canShoot)
        {
            Transform target = FindClosestEnemy();
            if (target != null)
            {
                Shoot();
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

        var attackTime = 1 / (atkSpd / 50f);
        yield return new WaitForSeconds(0.001f * attackTime);

        canShoot = true;
    }

    protected virtual void Shoot()
    {
        if (!canShoot) return;

        GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.identity);

        StartCoroutine(ShotCooldown());
    }

    protected virtual void Upgrade()
    {
        level++;
        if (level >= 3)
        {
            ShowUpgradeMenu();
        }
    }
    protected void ShowUpgradeMenu()
    {
        upgradePanel.SetActive(true);
    }

    public void OnUpgradePath1Selected()
    {
        SetPath1();
        CloseUpgradeMenu();
    }

    public void OnUpgradePath2Selected()
    {
        SetPath2();
        CloseUpgradeMenu();
    }

    protected void CloseUpgradeMenu()
    {
        upgradePanel.SetActive(false);
    }

    public void SetPath1()
    {
        InitializeTower(path1);
    }

    public void SetPath2()
    {
        InitializeTower(path2);
    }
}
