using UnityEngine;

public class ZombieChaseBehaviour : IEnemyBehaviour
{
    private Zombie _zombie;

    public ZombieChaseBehaviour(Zombie zombie)
    {
        _zombie = zombie;
    }

    public void EnterState()
    {
        //Debug.Log("Enter CHASe State");
    }

    public void ExitState()
    {
        //Debug.Log("Exit CHASe State");
    }

    public void UpdateState()
    {
        _zombie.ChaseEnemyBehaviour();
    }
}
