using UnityEngine;

namespace Player
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField] protected int m_health;
        [SerializeField] protected int m_maxHealth;
        [SerializeField] protected bool m_isDead;

        [SerializeField] protected int m_stamina;
        [SerializeField] protected int m_maxStamina;
        [SerializeField] protected bool m_isStaminaGone;

        [SerializeField] protected int m_hunger;
        [SerializeField] protected int m_maxHunger;
        [SerializeField] protected bool m_isHungerGone;

        private void Awake()
        {
            InitVariables();
        }

        public void CheckHealth()
        {
            if (m_health <= 0)
            {
                m_health = 0;
                Die();
            }
            if (m_health >= m_maxHealth)
            {
                m_health = m_maxHealth;
            }
        }

        public void CheckStamina()
        {
            if (m_stamina <= 0)
            {
                m_stamina = 0;
                StaminaOut();
            }
            if (m_stamina >= m_maxStamina)
            {
                m_stamina = m_maxStamina;
            }
        }

        public void CheckHunger()
        {
            if (m_hunger <= 0)
            {
                m_hunger = 0;
                HungerOut();
            }
            if (m_hunger >= m_maxHunger)
            {
                m_hunger = m_maxHunger;
            }
        }

        public void Die()
        {
            m_isDead = true;
        }

        public void StaminaOut()
        {
            m_isStaminaGone = true;
        }

        public void HungerOut()
        {
            m_isHungerGone = true;
        }

        private void SetHealthTo(int healthToSet)
        {
            m_health = healthToSet;
            CheckHealth();
        }
    
        private void SetStaminaTo(int staminaToSet)
        {
            m_stamina = staminaToSet;
            CheckStamina();
        }
    
        private void SetHungerTo(int hungerToSet)
        {
            m_hunger = hungerToSet;
            CheckHunger();
        }

        public void TakeDamage(int damage)
        {
            int healthAfterDamage = m_health - damage;
            SetHealthTo(healthAfterDamage);
        }

        public void TakeStamina(int stamina)
        {
            int staminaAfterUsed = m_stamina - stamina;
            SetStaminaTo(staminaAfterUsed);
        }
    
        public void TakeHunger(int hunger)
        {
            int hungerAfterUsed = m_hunger - hunger;
            SetHungerTo(hungerAfterUsed);
        }

        public void Heal(int heal)
        {
            int healthAfterHeal = m_health + heal;
            SetHealthTo(healthAfterHeal);
        }
    
        public void HealStamina(int healStamina)
        {
            int staminaAfterHeal = m_stamina + healStamina;
            SetStaminaTo(staminaAfterHeal);
        }
    
        public void HealHunger(int healHunger)
        {
            int hungerAfterHeal = m_hunger + healHunger;
            SetHungerTo(hungerAfterHeal);
        }

        public void InitVariables()
        {
            m_maxHealth = 100;
            m_maxStamina = 100;
            m_maxHunger = 100;
            SetHealthTo(m_maxHealth);
            SetStaminaTo(m_maxStamina);
            SetHungerTo(m_maxHunger);
            m_isDead = false;
            m_isStaminaGone = false;
            m_isHungerGone = false;
        }

    }
}
