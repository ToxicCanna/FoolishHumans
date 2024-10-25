using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TurretObject defaultData;
    public TurretObject path1;
    public TurretObject path2;
    public GameObject shotPrefab;

    private bool canShoot;

    public float atkSpd;
    public float atkDmg;
    public float range;
    public float area;
    public float chain;
    public int level;
    public int cost;

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

    private void Shoot()
    {

    }

    public virtual void Upgrade()
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
