using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] private PlayerStats m_playerStats;
    private bool m_isDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (m_isDamage)
        {
            Damage();
        }
    }

    void Damage()
    {
        m_playerStats.TakeHealth(Random.Range(5,15));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_isDamage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_isDamage = false;
        }
    }
}
