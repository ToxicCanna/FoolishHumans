using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleTower : Tower
{
    protected override void Upgrade()
    {
        base.Upgrade();

        if (level == 2)
        {

        }
    }

    protected override void Shoot()
    {
        // Instead of shooting a projectile, summon a skeleton
        SummonSkeleton();
        StartCoroutine(ShotCooldown());
    }

    private void SummonSkeleton()
    {

    }
}
