using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Public")] 
    public int m_woodHeld;
    public int m_rockHeld;
    public int m_coinsHeld;
    public TextMeshProUGUI m_woodText;
    public TextMeshProUGUI m_rockText;
    public TextMeshProUGUI m_coinText;
}
