using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullMace : EnemyWeaponAbstract
{
    private void OnTriggerEnter(Collider col)
    {
        HitPlayer(col);
    }
}
