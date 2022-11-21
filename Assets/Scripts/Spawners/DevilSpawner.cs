using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilSpawner : MonoBehaviour
{
    [SerializeField] private Devil _devilPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _autoExpand = false;

    private PoolEnemies<Devil> poolEnemies;

    private void Awake()
    {
        poolEnemies = new PoolEnemies<Devil>(_devilPrefab, 3, _container);
        poolEnemies.autoExpand = _autoExpand;
    }

    public void SpawnDevil()
    {
        poolEnemies.GetFreeElement();
    }
}
