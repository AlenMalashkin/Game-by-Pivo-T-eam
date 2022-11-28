using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Items")]
public class Item : ScriptableObject
{
    [SerializeField] private int _itemId;
    [SerializeField] private string _itemDamage;
    [SerializeField] private Sprite _itemImage;

    public int itemId => _itemId;
    public string itemDamage => _itemDamage;
    public Sprite itemImage => _itemImage;
}
