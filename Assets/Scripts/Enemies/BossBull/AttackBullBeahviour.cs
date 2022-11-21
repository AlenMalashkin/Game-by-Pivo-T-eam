using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBullBeahviour : IEnemyBehaviour
{
    private BossBull _component;

    public AttackBullBeahviour(BossBull component)
    {
        _component = component;
    }

    public void EnterState()
    {
        _component.AttackEnemyBehaviour();
    }

    public void ExitState()
    {
    }

    public void UpdateState()
    {
        
    }
}
