using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SpawnSystem : MonoBehaviour
{
    private List<ISpawner> _spawners;

    private void Awake()
    {
        _spawners = new List<ISpawner>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawners.Add(transform.GetChild(i).GetComponent<ISpawner>());
        }
    }

    private void Start()
    {
        foreach (var spawner in _spawners)
        {
            for (int i = 0; i < spawner.GetEnemiesRemain(); i++)
            {
                spawner.Spawn();
            }
        }

        StartCoroutine(EnemyAliveCheckRoutine());
    }

    private void CheckEnemiesAlive()
    {
        int spawnersEnd = 0;

        foreach (var spawner in _spawners)
        {
            if (spawner.CheckEnemiesRemain())
                spawnersEnd += 1;

            Debug.Log(spawnersEnd);

            if (spawnersEnd == 4)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private IEnumerator EnemyAliveCheckRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            CheckEnemiesAlive();
        }     
    }
}
