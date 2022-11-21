using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDieBehaviour : IEnemyBehaviour
{
    private Zombie _zombie;

    public ZombieDieBehaviour(Zombie zombie)
    {
        _zombie = zombie;
    }

    public void EnterState()
    {
        //Debug.Log("Enter Die State");
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
