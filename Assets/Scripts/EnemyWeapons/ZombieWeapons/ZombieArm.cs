using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieArm : EnemyWeaponAbstract
{
    private void OnTriggerEnter(Collider col)
    {
        HitPlayer(col);
    }
}
