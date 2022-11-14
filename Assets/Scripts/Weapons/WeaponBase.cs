using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IPlayerWeapon
{
    [SerializeField] private int damage;
    [SerializeField] private Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyAbstract enemy))
        {
            enemy.TakeHit(damage);
            col.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        col.enabled = true;
    }

    public void HitTarget(Collider other)
    {

    }
}
