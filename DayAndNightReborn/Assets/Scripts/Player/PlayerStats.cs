using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    public float m_health;
    public float m_maxHealth;
    public TextMeshProUGUI m_healthText;
    [Space]
    [Header("Stamina")]
    public float m_stamina;
    public float m_maxStamina;
    public float m_staminaCooldown;
    public bool m_allowSprintOrJump;
    public TextMeshProUGUI m_staminaText;
    [Space]
    [Header("Hunger")]
    public float m_hunger;
    public float m_maxHunger;
    public TextMeshProUGUI m_hungerText;
    
    [SerializeField] private float m_invincibilityFrames;
    [SerializeField] private float m_lastTimeHit;

    private void Start()
    {
        m_health = m_maxHealth;
        m_stamina = m_maxStamina;
        m_hunger = m_maxHunger;
    }

    private void Update()
    {
        m_hunger -= Time.deltaTime;
        m_hungerText.text = m_hunger.ToString("0") + " / 100";

        m_healthText.text = m_health.ToString("0") + " / 100";

        if (m_stamina <= 0)
        {
            m_stamina = 0;
        }
        if (m_hunger <= 0)
        {
            m_hunger = 0;
        }

        if (m_health <= 0)
        {
            Die();
        }

        if (m_health > m_maxHealth)
        {
            m_health = m_maxHealth;
        }        
        if (m_stamina > m_maxStamina)
        {
            m_stamina = m_maxStamina;
        }
        if (m_hunger > m_maxHunger)
        {
            m_hunger = m_maxHunger;
        }

        m_lastTimeHit += Time.deltaTime;

    }

    public void TakeStamina(float amount)
    {
        m_stamina -= amount;
        m_staminaText.text = m_stamina.ToString("0") + " / 100";
    }

    public void GiveStamina(float amount)
    {
        m_stamina += amount;
        m_staminaText.text = m_stamina.ToString("0") + " / 100";
    }

    public void TakeHealth(float amount)
    {
        if (m_lastTimeHit < m_invincibilityFrames) {
            return;
        }
        m_lastTimeHit = 0;
        m_health -= amount;
        m_healthText.text = m_health.ToString("0") + " / 100";
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            TakeHealth(12);
        }
        

        if (other.gameObject.CompareTag("Bow"))
        {
            TakeHealth(8);
        }
        
        if (other.gameObject.CompareTag("Skeleton"))
        {
            TakeHealth(7);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Death_Scene");
    }
}
