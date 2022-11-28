using UnityEngine;

public class ZombieChaseBehaviour : IEnemyBehaviour
{
    private Zombie _zombie;
    private ZombieSFX _zombieSFX;

    public ZombieChaseBehaviour(Zombie zombie, ZombieSFX zombieSFX)
    {
        _zombie = zombie;
        _zombieSFX = zombieSFX;
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
