using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponColliderEnabler : MonoBehaviour
{
    [SerializeField] private Collider col;

    public void EnableAttackCollider()
    {
        col.enabled = true;
    }

    public void DisableAttackCollider()
    {
        col.enabled = false;
    }
}
