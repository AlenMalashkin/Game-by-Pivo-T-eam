using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour
{
    public event Action<int> OnHealthValueChangedEvent;

    private int maxHealth;
    [SerializeField] private Image healthPrefab; 
    [SerializeField] private Sprite emptyHealthPrefab; 

    private PlayerHealth playerHealth;

    public List<Image> healthBar;
    private int currentHealth;

    private void OnEnable() => playerHealth.OnPlayerHitEvent += OnPlayerHit;
    private void OnDisable() => playerHealth.OnPlayerHitEvent -= OnPlayerHit;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();

        maxHealth = playerHealth.maxHealth;

        currentHealth = maxHealth;

        for (int i = 0; i < maxHealth; i++)
        {
            var hp = Instantiate(healthPrefab);
            hp.transform.SetParent(transform);
            healthBar.Add(hp);
        }
    }

    public void OnPlayerHit(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            playerHealth.Die();
            return;
        }      

        for (int i = maxHealth - 1; i > currentHealth; i--)
        {
            healthBar[i].sprite = emptyHealthPrefab;
        }

        OnHealthValueChangedEvent.Invoke(currentHealth);
    }
}
