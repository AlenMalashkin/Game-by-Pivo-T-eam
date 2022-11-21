using UnityEngine;

public class ZombieAttackBehaviour : IEnemyBehaviour
{
    private Zombie _zombie;

    public ZombieAttackBehaviour(Zombie zombie)
    {
        _zombie = zombie;
    }

    public void EnterState()
    {
        //Debug.Log("Enter ATTACK State");
    }

    public void ExitState()
    {
        //Debug.Log("Exit ATTACK State");
    }

    public void UpdateState()
    {
        //Debug.Log("Update ATTACK State");
        _zombie.AttackEnemyBehaviour();
    }
}
