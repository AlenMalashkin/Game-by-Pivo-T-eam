using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Zombie : EnemyAbstract
{
    [SerializeField] private float attackRadius;

    private Animator anim;
    private Player player;
    private NavMeshAgent navAgent;

    private float distance;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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

        enemyBehaviourMap[typeof(ZombieIdleBehaviour)] = new ZombieIdleBehaviour(this);
        enemyBehaviourMap[typeof(ZombieChaseBehaviour)] = new ZombieChaseBehaviour(this);
        enemyBehaviourMap[typeof(ZombieAttackBehaviour)] = new ZombieAttackBehaviour(this);
        enemyBehaviourMap[typeof(ZombieDieBehaviour)] = new ZombieDieBehaviour(this);
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
        SetChaseEnemyBehaviour();
    }

    public void SetIdleEnemyBehaviour()
    {
        var behaviour = GetEnemyBehaviour<ZombieIdleBehaviour>();
        SetBehaviour(behaviour);
    }

    public void SetChaseEnemyBehaviour()
    {
        var behaviour = GetEnemyBehaviour<ZombieChaseBehaviour>();
        SetBehaviour(behaviour);
    }

    public void SetAttackEnemyBehaviour()
    {
        var behaviour = GetEnemyBehaviour<ZombieAttackBehaviour>();
        SetBehaviour(behaviour);
    }

    public void SetDieEnemyBehaviour()
    {
        var behaviour = GetEnemyBehaviour<ZombieDieBehaviour>();
        SetBehaviour(behaviour);
    }

    public void IdleEnemyBehaviour()
    {
        navAgent.enabled = false;
        anim.SetBool("Idle", true);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Die", false);
    }

    public void ChaseEnemyBehaviour()
    {
        navAgent.enabled = true;
        anim.SetBool("Idle", false);
        anim.SetBool("Run", true);
        anim.SetBool("Attack", false);
        anim.SetBool("Die", false);
        navAgent.SetDestination(player.transform.position);
    }

    public void AttackEnemyBehaviour()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", true);
        anim.SetBool("Die", false);
    }

    public void DieBehavoiur()
    {
        navAgent.enabled = false;
        this.enabled = false;
        anim.SetTrigger("Die");
        Destroy(gameObject, 3);
    }
}
