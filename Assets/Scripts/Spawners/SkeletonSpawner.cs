using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private Skeleton _skeletonPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _autoExpand = false;

    private CountEnemiesOnLevel count;
    private PoolEnemies<Skeleton> poolEnemies;

    private void Awake()
    {
        count = Resources.Load<CountEnemiesOnLevel>($"LevelController/{PlayerPrefs.GetString("Level")}");
        poolEnemies = new PoolEnemies<Skeleton>(_skeletonPrefab, 3, _container);
        poolEnemies.autoExpand = _autoExpand;
    }

    public void Spawn()
    {
        poolEnemies.GetFreeElement();
    }

    public int GetEnemiesRemain()
    {
        return count.skeletonCount;
    }
}
