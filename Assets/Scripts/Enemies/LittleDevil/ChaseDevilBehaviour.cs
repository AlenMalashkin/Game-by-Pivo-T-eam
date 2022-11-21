using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseDevilBehaviour : IEnemyBehaviour
{
    private Devil _component;

    public ChaseDevilBehaviour(Devil component)
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
