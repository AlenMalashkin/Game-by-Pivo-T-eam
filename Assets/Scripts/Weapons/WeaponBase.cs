using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IPlayerWeapon
{
    [SerializeField] private int damage;
    [SerializeField] private Collider col;
    [SerializeField] private PlayerSFX playerSFX;

    private void OnTriggerEnter(Collider other)
    {
        HitTarget(other);
        playerSFX.PlayAttackSFX();
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.activeInHierarchy)
            col.enabled = true;
    }

    public void HitTarget(Collider other)
    {
        if (other.TryGetComponent(out EnemyAbstract enemy))
        {
            enemy.TakeHit(damage);
            if (gameObject.activeInHierarchy)
                col.enabled = false;
        }
    }
}
