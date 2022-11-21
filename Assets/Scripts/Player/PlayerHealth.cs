using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public event Action<int> OnPlayerHitEvent;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int _maxHealth;
    public int maxHealth => _maxHealth;

    private PlayerAnimations playerAnimations;

    private void OnEnable() => healthBar.OnHealthValueChangedEvent += OnHealthValueChanged;
    private void OnDisable() => healthBar.OnHealthValueChangedEvent -= OnHealthValueChanged;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void OnHealthValueChanged(int changedHealth)
    {
        if (changedHealth <= 0)
        {
            this.enabled = false;
        }
    }

    public void TakeHit(int damage)
    {
        OnPlayerHitEvent.Invoke(damage);
    }

    public void Die()
    {
        playerAnimations.SetDieAnimation();
    }

    public void GoToPrevScene()
    {
        SceneManager.LoadScene(0);
    }
}
