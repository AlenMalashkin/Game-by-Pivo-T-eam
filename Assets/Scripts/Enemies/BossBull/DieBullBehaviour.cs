using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBullBehaviour : IEnemyBehaviour
{
    private BossBull _component;

    public DieBullBehaviour(BossBull component)
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
