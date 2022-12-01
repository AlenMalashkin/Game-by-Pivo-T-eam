using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleDevilBehaviour : IEnemyBehaviour
{
    private Devil _component;
    private DevilSFX _devilSFX;

    public IdleDevilBehaviour(Devil component, DevilSFX devilSFX)
    {
        _component = component;
        _devilSFX = devilSFX;
    }

    public void EnterState()
    {
        _devilSFX.PlayIdleSFX();
    }

    public void ExitState()
    {
    }

    public void UpdateState()
    {
        _component.IdleEnemyBehaviour();
    }
}
