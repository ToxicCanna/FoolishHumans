using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinTower : Tower
{
    public override void Upgrade()
    {
        level++;
        atkSpd += 0.1f;
        atkDmg += 5;
    }
}
