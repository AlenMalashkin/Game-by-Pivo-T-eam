using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteractor : MonoBehaviour
{
    [SerializeField] private ShopPanel shopPanel;

    private void OnTriggerEnter(Collider other)
    {
        CursorEnabler.Instance.EnableCursor();

        if (other.tag == "PlayerContactTrigger")
            shopPanel.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        CursorEnabler.Instance.DisableCursor();

        if (other.tag == "PlayerContactTrigger")
            shopPanel.gameObject.SetActive(false);
    }
}
