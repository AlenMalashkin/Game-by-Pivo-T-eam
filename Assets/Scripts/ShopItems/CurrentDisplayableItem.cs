using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentDisplayableItem : MonoBehaviour
{
    [SerializeField] private Text _itemDamage;
    [SerializeField] private Image _itemImage;
    private int _itemId;

    public void DisplayInfo(int itemId, string itemDamage, Sprite itemImage)
    {
        _itemId = itemId;
        _itemDamage.text = itemDamage;
        _itemImage.sprite = itemImage;
    }
}
