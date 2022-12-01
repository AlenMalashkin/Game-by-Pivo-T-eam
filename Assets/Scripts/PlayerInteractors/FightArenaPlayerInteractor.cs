using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightArenaPlayerInteractor : MonoBehaviour
{
    [SerializeField] private FightArenaPanel arenaPanel;

    private void OnTriggerEnter(Collider other)
    {
        CursorEnabler.Instance.EnableCursor();

        if (other.tag == "PlayerContactTrigger")
            arenaPanel.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        CursorEnabler.Instance.DisableCursor();

        if (other.tag == "PlayerContactTrigger")
            arenaPanel.gameObject.SetActive(false);
    }
}
