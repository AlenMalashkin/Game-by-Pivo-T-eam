using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilArm : EnemyWeaponAbstract
{
    private void OnTriggerEnter(Collider col)
    {
        HitPlayer(col);
    }
}
