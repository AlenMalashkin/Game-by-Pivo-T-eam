using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieDevilBehaviour : IEnemyBehaviour
{
    private Devil _component;

    public DieDevilBehaviour(Devil component)
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
