using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MushroomStats : ScriptableObject
{
    [Header("Public Mushroom Stats")] 
    public float m_healthToGive;
    public float m_staminaToGive;
    public float m_hungerToGive;
}
