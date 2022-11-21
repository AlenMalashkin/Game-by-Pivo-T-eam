using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void InitBehaciours();
    void SetBehaviour(IEnemyBehaviour enemyBehaviour);
    IEnemyBehaviour GetEnemyBehaviour<T>() where T : IEnemyBehaviour;
    void SetEnemyBehaviourByDefault();
    void TakeHit(int damage);
    void Die();
}
