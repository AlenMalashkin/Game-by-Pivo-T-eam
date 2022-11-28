using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Devil : EnemyAbstract
{
    private Animator anim;
    private Player player;
    private NavMeshAgent navAgent;
    private DevilSFX devilSFX;

    private float distance;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        devilSFX = GetComponent<DevilSFX>();
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        InitBehaciours();
        SetEnemyBehaviourByDefault();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (currentBehavoiur != null)
            currentBehavoiur.UpdateState();

        if (distance > 3)
        {
            SetChaseEnemyBehaviour();
        }

        Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerContactTrigger")
            SetAttackEnemyBehaviour();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerContactTrigger")
            SetChaseEnemyBehaviour();
    }

    public override void InitBehaciours()
    {
        enemyBehaviourMap = new Dictionary<Type, IEnemyBehaviour>();

        enemyBehaviourMap[typeof(IdleDevilBehaviour)] = new IdleDevilBehaviour(this, devilSFX);
        enemyBehaviourMap[typeof(ChaseDevilBehaviour)] = new ChaseDevilBehaviour(this);
        enemyBehaviourMap[typeof(AttackDeveilBehaviour)] = new AttackDeveilBehaviour(this);
        enemyBehaviourMap[typeof(DieDevilBehaviour)] = new DieDevilBehaviour(this);
    }

    public override void Die()
    {
        if (health < 0)
        {
            SetDieEnemyBehaviour();
        }
    }

    public override void SetEnemyBehaviourByDefault()
    {
        SetIdleEnemyBehaviour();
    }

    public void SetIdleEnemyBehaviour()
    {
        var behaviour = GetEnemyBehaviour<IdleDevilBehaviour>();
        SetBehaviour(behaviour);
    }

    public void SetChaseEnemyBehaviour()
    {
        var behaviour = GetEnemyBehaviour<ChaseDevilBehaviour>();
        SetBehaviour(behaviour);
    }

    public void SetAttackEnemyBehaviour()
    {
        var behaviour = GetEnemyBehaviour<AttackDeveilBehaviour>();
        SetBehaviour(behaviour);
    }

    public void SetDieEnemyBehaviour()
    {
        var behaviour = GetEnemyBehaviour<DieDevilBehaviour>();
        SetBehaviour(behaviour);
    }

    public void IdleEnemyBehaviour()
    {
        navAgent.enabled = false;
        anim.SetBool("Idle", true);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);
    }

    public void ChaseEnemyBehaviour()
    {
        navAgent.enabled = true;
        anim.SetBool("Idle", false);
        anim.SetBool("Run", true);
        anim.SetBool("Attack", false);
        navAgent.SetDestination(player.transform.position);
    }

    public void AttackEnemyBehaviour()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", true);
    }

    public void DieBehavoiur()
    {
        navAgent.enabled = false;
        this.enabled = false;
        anim.SetTrigger("Die");
        Destroy(gameObject, 7);
    }
}
