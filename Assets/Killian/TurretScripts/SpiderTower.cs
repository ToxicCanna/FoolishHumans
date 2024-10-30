using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTower : Tower
{
    public override void Upgrade()
    {
        base.Upgrade();

        if (level == 2)
        {
            range += 5;
            area += 0.5f;
            atkSpd += 10;
        }
    }
}
