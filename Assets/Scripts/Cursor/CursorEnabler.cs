using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorEnabler : MonoBehaviour
{
    public static CursorEnabler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    public void EnableCursor()
    {
        Cursor.visible = true;
    }

    public void DisableCursor()
    {
        Cursor.visible = false;
    }
}
