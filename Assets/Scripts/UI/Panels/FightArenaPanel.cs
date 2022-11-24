using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightArenaPanel : MonoBehaviour
{
    public void LoadArena(string name)
    {
        PlayerPrefs.SetString("Level", name);
        SceneManager.LoadScene(1);   
    }
}
