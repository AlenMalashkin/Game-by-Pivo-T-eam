using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CountEnemiesOnLevel", menuName = "LevelController")]
public class CountEnemiesOnLevel : ScriptableObject
{
    [SerializeField] private int _zombieCount;
    [SerializeField] private int _devilCount;
    [SerializeField] private int _bullCount;
    [SerializeField] private int _skeletonCount;
    
    public int zombieCount => _zombieCount;
    public int devilCount => _devilCount;
    public int bullCount => _bullCount;
    public int skeletonCount => _skeletonCount;
}
