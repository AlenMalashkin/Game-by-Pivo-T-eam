using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] Transform itemImagesContainer;
    [SerializeField] Item[] items;
    [SerializeField] ItemElement itemPrefab;
    [SerializeField] private CurrentDisplayableItem _displayableItem;

    private void Awake()
    {
        foreach (var item in items)
        {
            var el = Instantiate(itemPrefab);
            el.transform.SetParent(itemImagesContainer);
            el.Init(item.itemId, item.itemDamage, item.itemImage, _displayableItem);
        }
    }
}
