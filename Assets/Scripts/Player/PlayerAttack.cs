using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Collider weaponCollider;
    private PlayerMotion playerMotion;

    private void OnEnable() => healthBar.OnHealthValueChangedEvent += OnHealthValueChanged;
    private void OnDisable() => healthBar.OnHealthValueChangedEvent -= OnHealthValueChanged;

    private void OnHealthValueChanged(int changedHealth)
    {
        if (changedHealth <= 0)
        {
            this.enabled = false;
        }
    }

    private void Awake()
    {
        weaponCollider = weaponCollider.GetComponent<Collider>();
        playerMotion = GetComponent<PlayerMotion>();
    }

    public void EnableWeaponCollider()
    {
        weaponCollider.enabled = true;
        playerMotion.canMove = false;
    }

    public void DisableWeaponCollider()
    {
        weaponCollider.enabled = false;
        playerMotion.canMove = true;
    }
}
