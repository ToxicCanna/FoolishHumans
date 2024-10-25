using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinTower : MonoBehaviour
{
    public TurretObject defaultData;
    public TurretObject path1;
    public TurretObject path2;
    public bool isPathA;
    public bool canShoot;

    private float atkSpd;
    private float atkDmg;
    private float range;
    private int level;
    private int cost;

    private void Awake()
    {
        atkSpd = defaultData.atkSpd;
        atkDmg = defaultData.atkDmg;
        range = defaultData.range;
        level = defaultData.level;
        cost = defaultData.cost;
    }
    private void Update()
    {
        //if enemy is in range and shoot is off cd, shoot
    }

    private void Shoot()
    {

    }

    private void Upgrade()
    {
        if (level == 1)
        {
            level++;
            atkSpd += 0.1f;
            atkDmg += 5;
            //data.range;
        }
        else if (level == 2)
        {
            MaxUp();
        }
    }
    private void MaxUp(TurretObject newPath)
    {
       
    }


}
