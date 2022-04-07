using System;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [Header("Private")] 
    [SerializeField] private MushroomStats m_mStats;
    [SerializeField] private PlayerStats m_playerStats;
    [SerializeField] private GameObject m_displayInteractMSG;
    [SerializeField] private bool m_inRange;

    private void Start()
    {
        m_displayInteractMSG.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && m_inRange)
        {
            Interact();
        }
    }

    public void GiveStats()
    {
        if (m_playerStats.m_health < 100.0f)
        {
            m_playerStats.m_health += m_mStats.m_healthToGive;
            m_playerStats.m_stamina += m_mStats.m_staminaToGive;
            m_playerStats.m_hunger += m_mStats.m_hungerToGive;
        }
        if (m_playerStats.m_hunger < 100.0f)
        {
            m_playerStats.m_hunger += m_mStats.m_hungerToGive;
            m_playerStats.m_health += m_mStats.m_healthToGive;
            m_playerStats.m_stamina += m_mStats.m_staminaToGive;
        }
        if (m_playerStats.m_stamina < 100.0f)
        {
            m_playerStats.m_stamina += m_mStats.m_staminaToGive;
            m_playerStats.m_hunger += m_mStats.m_hungerToGive;
            m_playerStats.m_health += m_mStats.m_healthToGive;
        }
    }

    private void Interact()
    {
        GiveStats();
        m_displayInteractMSG.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_inRange = true;
            m_displayInteractMSG.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_inRange = false;
            m_displayInteractMSG.SetActive(false);
        }
    }
    
}
