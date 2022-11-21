using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDeveilBehaviour : IEnemyBehaviour
{
    private Devil _component;

    public AttackDeveilBehaviour(Devil component)
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
