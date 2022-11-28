using UnityEngine;

public class ZombieIdleBehaviour : IEnemyBehaviour
{
    private Zombie _zombie;
    private ZombieSFX _zombieSFX;

    public ZombieIdleBehaviour(Zombie zombie, ZombieSFX zombieSFX)
    {
        _zombie = zombie;
        _zombieSFX = zombieSFX;
    }

    public void EnterState()
    {
        //Debug.Log("Enter IDLE State");
        _zombie.IdleEnemyBehaviour();
    }

    public void ExitState()
    {
        //_zombieSFX.PlayIdleSFX();
    }

    public void UpdateState()
    {
        //Debug.Log("Update IDLE State");
    }
}
