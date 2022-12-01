using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemElement : MonoBehaviour
{
    private CurrentDisplayableItem _displayableItem;
    private int _itemId;
    private string _itemDamage;
    private Sprite _itemImage;

    public void Init(int itemId, string itemDamage, Sprite itemImage, CurrentDisplayableItem displayableItem)
    {
        _itemId = itemId;
        _itemDamage = itemDamage;
        _itemImage = itemImage;
        _displayableItem = displayableItem;
        
        GetComponent<Image>().sprite = itemImage;
    }

    public void DisplayItemInfo()
    {
        _displayableItem.DisplayInfo(_itemId, _itemDamage, _itemImage);
    }
}
