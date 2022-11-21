using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Zombie _zombiePrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _autoExpand = false;

    private PoolEnemies<Zombie> poolEnemies;

    private void Awake()
    {
        poolEnemies = new PoolEnemies<Zombie>(_zombiePrefab, 3, _container);
        poolEnemies.autoExpand = _autoExpand;
    }


    public void SpawnZombie()
    {
        poolEnemies.GetFreeElement();
    }
}
