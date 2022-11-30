using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private Devil _devilPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _autoExpand = false;

    private CountEnemiesOnLevel count;
    private PoolEnemies<Devil> poolEnemies;

    private void Awake()
    {
        count = Resources.Load<CountEnemiesOnLevel>($"LevelController/{PlayerPrefs.GetString("Level")}");

        poolEnemies = new PoolEnemies<Devil>(_devilPrefab, 3, _container);
        poolEnemies.autoExpand = _autoExpand;
    }

    public void Spawn()
    {
        poolEnemies.GetFreeElement();
    }

    public int GetEnemiesRemain()
    {
        return count.devilCount;
    }

    public bool CheckEnemiesRemain()
    {
        if (transform.childCount == 0 || !transform.GetChild(0).gameObject.activeInHierarchy)
        {
            return true;
        }

        return false;
    }
}
