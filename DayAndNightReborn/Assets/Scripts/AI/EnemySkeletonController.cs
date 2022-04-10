using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemySkeletonController : MonoBehaviour
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
    
    // Start is called before the first frame update
    void Start()
    {
        attackRadius = 15f;
        m_enemyHP = m_enemyMaxHP;
        m_playerTarget = GameObject.Find("Player").GetComponent<Transform>();
        m_enemyAgent = GetComponent<NavMeshAgent>();
        m_enemyAnim = GetComponent<Animator>();
        m_EG = GameObject.Find("Skeleton_Gen").GetComponent<EnemyGenerator>();
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
    }
    
    void Die()
    {
        m_enemyAgent.speed = 0;
        m_enemyAnim.SetTrigger("Die");
        m_enemyAnim.SetBool("isAttacking", false);
        m_enemyAnim.SetBool("isChasing", false);
        Destroy(gameObject, 3.2f);
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
        m_enemyHP -= amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword") || other.gameObject.CompareTag("Axe") || other.gameObject.CompareTag("Pickaxe"))
        {
            TakeDamage(Random.Range(5.5f, 9.5f));
        }
    }
}
