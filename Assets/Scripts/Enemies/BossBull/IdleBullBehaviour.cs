using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBullBehaviour : IEnemyBehaviour
{
    private BossBull _component;
    private BullSFX _bullSFX;

    public IdleBullBehaviour(BossBull component, BullSFX bullSFX)
    {
        _component = component;
        _bullSFX = bullSFX;
    }

    public void EnterState()
    {
        _bullSFX.PlayIdleSFX();
    }

    public void ExitState()
    {
    }

    public void UpdateState()
    {
        _component.IdleEnemyBehaviour();
    }
}
