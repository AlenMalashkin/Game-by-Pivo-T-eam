using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private ZombieSpawner _zombieSpawner;
    [SerializeField] private SkeletonSpawner _skeletonSpawner;
    [SerializeField] private DevilSpawner _devilSpawner;
    [SerializeField] private BullSpawner _bullSpawner;

    private int zombieEnemiesRemain = 2;
    private int skeletonEnemiesRemain = 2;
    private int devilEnemiesRemain = 2;
    private int bullEnemiesRemain = 2;

    private void Awake()
    {
    }

    private void Start()
    {
        for (int i = 0; i < zombieEnemiesRemain; i++)
        {
            Spawn(_zombieSpawner.SpawnZombie);
        }

        for (int i = 0; i < skeletonEnemiesRemain; i++)
        {
            Spawn(_skeletonSpawner.SpawnSkeleton);
        }

        for (int i = 0; i < devilEnemiesRemain; i++)
        {
            Spawn(_devilSpawner.SpawnDevil);
        }

        for (int i = 0; i < bullEnemiesRemain; i++)
        {
            Spawn(_bullSpawner.SpawnBull);
        }
    }

    private void Spawn(Action Action)
    {
        Action();
    }
}
