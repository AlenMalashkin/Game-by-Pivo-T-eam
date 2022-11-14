using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAbstract : MonoBehaviour, IEnemy
{
    [SerializeField] private int _health;
    public int health => _health;

    public Dictionary<Type, IEnemyBehaviour> enemyBehaviourMap;
    public IEnemyBehaviour currentBehavoiur;

    public virtual void InitBehaciours() { }

    public void SetBehaviour(IEnemyBehaviour enemyBehaviour)
    {
        if (currentBehavoiur != null)
            currentBehavoiur.ExitState();
        
        currentBehavoiur = enemyBehaviour;
        currentBehavoiur.EnterState();
    }

    public IEnemyBehaviour GetEnemyBehaviour<T>() where T : IEnemyBehaviour
    {
        var type = typeof(T);
        return enemyBehaviourMap[type];
    }

    public virtual void SetEnemyBehaviourByDefault() { }

    public void TakeHit(int damage)
    {
        Debug.Log($"Sword hits {this}");
        Debug.Log($"{health}");
        _health -= damage;
    }

    public virtual void Die() { }
}
