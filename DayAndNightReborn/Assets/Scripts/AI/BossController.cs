using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BossController : MonoBehaviour
{
    [Header("Private")]
    [SerializeField] private float attackRadius;
    [SerializeField] private float m_bossHP;
    [SerializeField] private float m_bossMaxHP;
    [SerializeField] private Transform m_playerTarget;
    [SerializeField] private GameObjectiveManager m_GOM;
    [SerializeField] private NavMeshAgent m_bossAgent;
    [SerializeField] private Animator m_bossAnim;
    [SerializeField] private Image m_healthUI;
    
    [SerializeField] private float m_invincibilityFrames;
    [SerializeField] private float m_lastTimeHit;

    // Start is called before the first frame update
    void Start()
    {
        attackRadius = 25f;
        m_bossHP = m_bossMaxHP;
        m_playerTarget = GameObject.Find("Player").GetComponent<Transform>();
        m_GOM = GameObject.Find("GameManager").GetComponent<GameObjectiveManager>();
        m_bossAgent = GetComponent<NavMeshAgent>();
        m_bossAnim = GetComponent<Animator>();
        m_healthUI = GameObject.Find("Boss_Health_Background_Green").GetComponent<Image>();
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
        
        FaceTarget();

        if (distance < attackRadius)
        {
            m_bossAnim.SetBool("isAttacking", true);
            m_bossAnim.SetBool("isChasing", false);
        }
        else
        {
            m_bossAnim.SetBool("isAttacking", false);
            m_bossAnim.SetBool("isChasing", true);
        }
        
        m_healthUI.fillAmount = m_bossHP / m_bossMaxHP;

        m_lastTimeHit += Time.deltaTime;
    }

    void Die()
    {
        m_GOM.m_bossIsSpawned = false;
        m_bossAgent.speed = 0;
        m_GOM.m_isFinalBossKilled = true;
        m_bossAnim.SetTrigger("Die");
        m_bossAnim.SetBool("isAttacking", false);
        m_bossAnim.SetBool("isChasing", false);
        Destroy(gameObject, 2.5f);
    }

    void FaceTarget()
    {
        Vector3 direction = (m_playerTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }

    void TakeDamage(float amount)
    {
        if (m_lastTimeHit < m_invincibilityFrames) {
            return;
        }
        m_lastTimeHit = 0;
        m_bossHP -= amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword") || other.gameObject.CompareTag("Axe") || other.gameObject.CompareTag("Pickaxe"))
        {
            TakeDamage(Random.Range(5.5f, 7.5f));
        }
    }
}
