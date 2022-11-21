using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleBehaviour : IEnemyBehaviour
{
    private Skeleton _component;

    public SkeletonIdleBehaviour(Skeleton component)
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
        _component.IdleEnemyBehaviour();
    }
}
