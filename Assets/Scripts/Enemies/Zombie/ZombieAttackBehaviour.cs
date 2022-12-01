using UnityEngine;

public class ZombieAttackBehaviour : IEnemyBehaviour
{
    private Zombie _zombie;
    private ZombieSFX _zombieSFX;

    public ZombieAttackBehaviour(Zombie zombie, ZombieSFX zombieSFX)
    {
        _zombie = zombie;
        _zombieSFX = zombieSFX;
    }

    public void EnterState()
    {
        //_zombieSFX.PlayAttackSFX();
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
