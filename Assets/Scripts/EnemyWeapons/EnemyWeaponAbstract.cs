using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyWeaponAbstract : MonoBehaviour
{
    [SerializeField] private int damage;

    public virtual void HitPlayer(Collider col)
    {
        if (col.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeHit(damage);
        }
    }
}
