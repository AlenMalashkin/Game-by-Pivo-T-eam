using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonChaseBehaviour : IEnemyBehaviour
{
    private Skeleton _component;

    public SkeletonChaseBehaviour(Skeleton component)
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
        _component.ChaseEnemyBehaviour();
    }
}
