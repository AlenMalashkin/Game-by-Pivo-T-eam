using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    [SerializeField] private Skeleton _skeletonPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _autoExpand = false;

    private PoolEnemies<Skeleton> poolEnemies;

    private void Awake()
    {
        poolEnemies = new PoolEnemies<Skeleton>(_skeletonPrefab, 3, _container);
        poolEnemies.autoExpand = _autoExpand;
    }

    public void SpawnSkeleton()
    {
        poolEnemies.GetFreeElement();
    }
}
