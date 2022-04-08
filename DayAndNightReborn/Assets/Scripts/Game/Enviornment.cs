using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enviornment : MonoBehaviour
{
    [Header("Private")] 
    [SerializeField] private int m_resourceHealth;
    [SerializeField] private int m_woodToGive;
    [SerializeField] private int m_rockToGive;
    [SerializeField] private ParticleSystem m_resourceParticle;
    [SerializeField] private PlayerInventory m_PI;


    // Start is called before the first frame update
    void Start()
    {
        m_resourceHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    void DealDamage(int amount)
    {
        m_resourceHealth -= amount;
        m_resourceParticle.Play();
    }

    void Die()
    {
        if (m_resourceHealth <= 0)
        {
            if (gameObject.CompareTag("Tree"))
            {
                m_PI.m_woodHeld += m_woodToGive;
            }
            else if (gameObject.CompareTag("Rock"))
            {
                m_PI.m_rockHeld += m_rockToGive;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            if (gameObject.CompareTag("Tree"))
            {
                DealDamage(Random.Range(2, 14));
            }
        }

        if (other.gameObject.CompareTag("Pickaxe"))
        {
            if (gameObject.CompareTag("Rock"))
            {
                DealDamage(Random.Range(2, 14));
            }
        }
    }
}
