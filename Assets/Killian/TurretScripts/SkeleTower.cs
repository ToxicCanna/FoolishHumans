using Code.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using static UnityEngine.GraphicsBuffer;

public class SkeleTower : Tower
{
    public override void Upgrade()
    {
        base.Upgrade();

        if (level == 2)
        {
            atkSpd += 10;
            range += 5;
        }
    }
    protected override void Shoot(Transform target)
    {
        // No projectile, just summon skeletons
    }
    private void Start()
    {
        StartCoroutine(SummonSkeletons());
    }

    private IEnumerator SummonSkeletons()
    {
        while (true)
        {
            SummonSkeleton();
            yield return new WaitForSeconds(1f / (atkSpd / 50)); // Use attack speed to control the summon rate. Functions exactly the same as Tower ShotCooldown
        }
    }

    private void SummonSkeleton()
    {
        GameObject skeleton = Instantiate(shotPrefab, transform.position, Quaternion.identity, transform);
        AudioManager.Instance.PlayAudioint(3);
        Skeleton skeletonScript = skeleton.GetComponent<Skeleton>();
        if (skeletonScript != null)
        {
            skeletonScript.SetDamage(atkDmg);
        }
    }
}
