using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyBowController : MonoBehaviour
{
    [Header("Private")]
    [SerializeField] private float attackRadius;
    [SerializeField] private float m_enemyHP;
    [SerializeField] private float m_enemyMaxHP;
    [SerializeField] private Transform m_playerTarget;
    [SerializeField] private NavMeshAgent m_enemyAgent;
    [SerializeField] private Animator m_enemyAnim;
    [SerializeField] private Image m_healthUI;
    [SerializeField] private EnemyGenerator m_EG;
    [SerializeField] private float m_invincibilityFrames;
    [SerializeField] private float m_lastTimeHit;
    
    // Start is called before the first frame update
    void Start()
    {
        attackRadius = 15f;
        m_enemyHP = m_enemyMaxHP;
        m_playerTarget = GameObject.Find("Player").GetComponent<Transform>();
        m_enemyAgent = GetComponent<NavMeshAgent>();
        m_enemyAnim = GetComponent<Animator>();
        m_EG = GameObject.Find("Bow_Gen").GetComponent<EnemyGenerator>();
        m_enemyAgent.SetDestination(m_playerTarget.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(m_playerTarget.position, transform.position);
        
        m_enemyAgent.SetDestination(m_playerTarget.position);
        
        if (distance <= m_enemyAgent.stoppingDistance)
        {
            FaceTarget();
        }
        
        if (distance < attackRadius)
        {
            m_enemyAnim.SetBool("isAttacking", true);
            m_enemyAnim.SetBool("isChasing", false);
        }
        else
        {
            m_enemyAnim.SetBool("isAttacking", false);
            m_enemyAnim.SetBool("isChasing", true);
        }
        
        m_healthUI.fillAmount = m_enemyHP / m_enemyMaxHP;
        
        if (m_enemyHP <= 0)
        {
            Die();
        }
        
        m_lastTimeHit += Time.deltaTime;
    }
    
    void Die()
    {
        m_enemyAgent.speed = 0;
        m_enemyAnim.SetTrigger("Die");
        m_enemyAnim.SetBool("isAttacking", false);
        m_enemyAnim.SetBool("isChasing", false);
        Destroy(gameObject, 3.3f);
        m_EG.m_enemySpawned = 0;
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
        m_enemyHP -= amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            TakeDamage(Random.Range(20f, 30f));
        }

        if (other.gameObject.CompareTag("Axe"))
        {
            TakeDamage(15f);
        }

        if (other.gameObject.CompareTag("Pickaxe"))
        {
            TakeDamage(15f);
        }
    }
}
