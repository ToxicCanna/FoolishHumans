using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinTower : Tower
{
    public override void Upgrade()
    {
        base.Upgrade();

        if (level == 2)
        {
            atkSpd += 0.2f;
            atkDmg += 10;
        }
    }
}