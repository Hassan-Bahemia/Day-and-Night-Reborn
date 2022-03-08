using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapons : ScriptableObject
{
    public GameObject m_weapon;
    public enum WeaponType
    {
        Melee,
        Range
    }
    public float m_range;
    public float m_damage;
    public float m_recoveryRate;
    public float m_harvestDamage;
}
