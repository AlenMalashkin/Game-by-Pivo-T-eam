using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private Zombie _zombiePrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _autoExpand = false;

    private CountEnemiesOnLevel count;
    private PoolEnemies<Zombie> poolEnemies;

    private void Awake()
    {
        count = Resources.Load<CountEnemiesOnLevel>($"LevelController/{PlayerPrefs.GetString("Level")}");
        poolEnemies = new PoolEnemies<Zombie>(_zombiePrefab, 3, _container);
        poolEnemies.autoExpand = _autoExpand;
    }

    public void Spawn()
    {
        poolEnemies.GetFreeElement();
    }

    public int GetEnemiesRemain()
    {
        return count.zombieCount;
    }
}
