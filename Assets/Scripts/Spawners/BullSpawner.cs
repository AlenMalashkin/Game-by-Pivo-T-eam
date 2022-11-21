using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullSpawner : MonoBehaviour
{
    [SerializeField] private BossBull _bullPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _autoExpand = false;

    private PoolEnemies<BossBull> poolEnemies;

    private void Awake()
    {
        poolEnemies = new PoolEnemies<BossBull>(_bullPrefab, 3, _container);
        poolEnemies.autoExpand = _autoExpand;
    }

    public void SpawnBull()
    {
        poolEnemies.GetFreeElement();
    }
}
