using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinTower : Tower
{
    public GameObject bombPrefab;
    public override void Upgrade()
    {
        base.Upgrade();

        if (level == 2)
        {
            atkSpd += 25;
            atkDmg += 2;
        }
    }

    public override void SetPath2()
    {
        base.SetPath2();
        shotPrefab = bombPrefab;
    }
}