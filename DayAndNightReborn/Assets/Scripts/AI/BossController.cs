using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BossController : MonoBehaviour
{
    [Header("Private")]
    [SerializeField] private float attackRadius;
    [SerializeField] private int m_bossHP;
    [SerializeField] private Transform m_playerTarget;
    [SerializeField] private GameObjectiveManager m_GOM;
    [SerializeField] private NavMeshAgent m_bossAgent;
    [SerializeField] private Animator m_bossAnim;

    // Start is called before the first frame update
    void Start()
    {
        attackRadius = 25f;
        m_bossHP = 200;
        m_playerTarget = GameObject.Find("Player").GetComponent<Transform>();
        m_GOM = GameObject.Find("GameManager").GetComponent<GameObjectiveManager>();
        m_bossAgent = GetComponent<NavMeshAgent>();
        m_bossAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(m_playerTarget.position, transform.position);
        
        if (m_bossHP <= 0)
        {
            Die();
        }
        
        m_bossAgent.SetDestination(m_playerTarget.position);

        if (distance <= m_bossAgent.stoppingDistance)
        {
            FaceTarget();
        }

        if (distance < attackRadius)
        {
            m_bossAnim.SetTrigger("isAttacking");
            m_bossAnim.ResetTrigger("isChasing");
        }
        else
        {
            m_bossAnim.SetTrigger("isChasing");
            m_bossAnim.ResetTrigger("isAttacking");
        }

    }

    void Die()
    {
        m_GOM.m_isFinalBossKilled = true;
        m_bossAnim.SetTrigger("Die");
        Destroy(gameObject, 15f);
    }

    void FaceTarget()
    {
        Vector3 direction = (m_playerTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }

    void TakeDamage(int amount)
    {
        m_bossHP -= amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword") || other.gameObject.CompareTag("Axe") || other.gameObject.CompareTag("Pickaxe"))
        {
            TakeDamage(Random.Range(10, 15));
        }
    }
}
