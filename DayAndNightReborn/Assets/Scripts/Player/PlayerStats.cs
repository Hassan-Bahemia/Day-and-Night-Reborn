using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    public float m_health;
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
    public TextMeshProUGUI m_hungerText;


    private void Update()
    {
        m_hunger -= Time.deltaTime;
        m_hungerText.text = m_hunger.ToString("0") + " / 100";

        if (m_stamina <= 0)
        {
            m_stamina = 0;
        }
        if (m_hunger <= 0)
        {
            m_hunger = 0;
        }
    }

    public void TakeStamina(float amount)
    {
        m_stamina -= amount;
        m_staminaText.text = m_stamina.ToString("0") + " / 100";
    }

    public void GiveStamina(int amount)
    {
        m_stamina += amount;
        m_staminaText.text = m_stamina.ToString("0") + " / 100";
    }
    
}
