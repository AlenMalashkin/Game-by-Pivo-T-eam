using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArm : EnemyWeaponAbstract
{
    private void OnTriggerEnter(Collider col)
    {
        HitPlayer(col);
    }
}
