using UnityEngine;

public class ZombieIdleBehaviour : IEnemyBehaviour
{
    private Zombie _zombie;

    public ZombieIdleBehaviour(Zombie zombie)
    {
        _zombie = zombie;
    }

    public void EnterState()
    {
        //Debug.Log("Enter IDLE State");
        _zombie.IdleEnemyBehaviour();
    }

    public void ExitState()
    {
        //Debug.Log("Exit IDLE State");
    }

    public void UpdateState()
    {
        //Debug.Log("Update IDLE State");
    }
}
