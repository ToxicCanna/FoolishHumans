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

    private void Awake()
    {
        atkSpd = defaultData.atkSpd;
        atkDmg = defaultData.atkDmg;
        range = defaultData.range;
        area = defaultData.area;
        chain = defaultData.chain;
        level = defaultData.level;
        cost = defaultData.cost;
    }

    public void Start()
    {
        var attackTime = 1 / (atkSpd / 50f);
        Debug.Log(attackTime);
    }

    private void Update()
    {

    }

    IEnumerator ShotCooldown()
    {
        // Block any attempt to shoot
        canShoot = false;

        // Wait for specified number of seconds
        var attackTime = 1 / (atkSpd / 50f);
        Debug.Log(attackTime);
        yield return new WaitForSeconds(0.001f * attackTime);

        // Cooldown is over. Unlock shot
        canShoot = true;
    }

    private void Shoot()
    {
        //shoot projectiles

        StartCoroutine(ShotCooldown());
    }

    protected virtual void Upgrade()
    {

    }
    private void MaxUp(TurretObject newPath)
    {
        atkSpd = newPath.atkSpd;
        atkDmg = newPath.atkDmg;
        range = newPath.range;
        area = newPath.area;
        chain = newPath.chain;
        level = newPath.level;
        cost =  newPath.cost;
    }

    public void SetPath1()
    {
        MaxUp(path1);
    }

    public void SetPath2()
    {
        MaxUp(path2);
    }
}
