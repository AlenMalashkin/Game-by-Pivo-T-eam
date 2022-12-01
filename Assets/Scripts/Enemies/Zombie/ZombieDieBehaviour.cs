using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDieBehaviour : IEnemyBehaviour
{
    private Zombie _zombie;
    private ZombieSFX _zombieSFX;

    public ZombieDieBehaviour(Zombie zombie, ZombieSFX zombieSFX)
    {
        _zombie = zombie;
        _zombieSFX = zombieSFX;
    }

    public void EnterState()
    {
        //_zombieSFX.PlayDieSFX();
    }

    public void ExitState()
    {
        //Debug.Log("Exit Die State");
    }

    public void UpdateState()
    {
        //Debug.Log("Update Die State");
        _zombie.DieBehavoiur();
    }
}
