using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackBehaviour : IEnemyBehaviour
{
    private Skeleton _component;

    public SkeletonAttackBehaviour(Skeleton component)
    {
        _component = component;
    }

    public void EnterState()
    {
    }

    public void ExitState()
    {
    }

    public void UpdateState()
    {
        _component.AttackEnemyBehaviour();
    }
}
