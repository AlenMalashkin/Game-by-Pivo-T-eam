using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDieBehaviour : IEnemyBehaviour
{
    private Skeleton _component;

    public SkeletonDieBehaviour(Skeleton component)
    {
        _component = component;
    }

    public void EnterState()
    {
        _component.DieBehavoiur();
    }

    public void ExitState()
    {
    }

    public void UpdateState()
    {
    }
}
