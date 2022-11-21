using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleDevilBehaviour : IEnemyBehaviour
{
    private Devil _component;

    public IdleDevilBehaviour(Devil component)
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
