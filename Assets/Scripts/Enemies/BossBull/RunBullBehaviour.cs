using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBullBehaviour : IEnemyBehaviour
{
    private BossBull _component;

    public RunBullBehaviour(BossBull component)
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
