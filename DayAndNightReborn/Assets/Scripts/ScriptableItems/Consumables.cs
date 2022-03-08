using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Consumable")]
public class Consumables : ScriptableObject
{
    public GameObject m_consumableToSpawn;
    public float m_healthGiven;
    public float m_staminaGiven;
    public float m_hungerGiven;
}
