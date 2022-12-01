using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private PausePanel pausePanel;
    private bool isPauseActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPauseActive = !isPauseActive;
            pausePanel.gameObject.SetActive(isPauseActive);
        }

        if (isPauseActive)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        isPauseActive = true;
        CursorEnabler.Instance.EnableCursor();
        Time.timeScale = 0;
        pausePanel.gameObject.SetActive(isPauseActive);
    }

    public void ResumeGame()
    {
        isPauseActive = false;
        CursorEnabler.Instance.DisableCursor();
        Time.timeScale = 1;
        pausePanel.gameObject.SetActive(isPauseActive);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
