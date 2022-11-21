using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBullBehaviour : IEnemyBehaviour
{
    private BossBull _component;

    public IdleBullBehaviour(BossBull component)
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
