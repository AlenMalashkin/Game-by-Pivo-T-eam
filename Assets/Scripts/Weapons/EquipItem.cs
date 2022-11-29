using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private PlayerAttack playerAttack;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("EquippedItem"))
        {
            ActivateEquippedItem();
        }
    }

    public void ActivateEquippedItem()
    {
        foreach (var item in weapons)
        {
            if (item.activeInHierarchy)
            {
                item.SetActive(false);
            }
        }

        weapons[PlayerPrefs.GetInt("EquippedItem")].SetActive(true);
        playerAttack.ChangeWeaponCollider(weapons[PlayerPrefs.GetInt("EquippedItem")].GetComponent<Collider>());
    }
}
