using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Public")] 
    public int m_woodHeld;
    public int m_rockHeld;
    public TextMeshProUGUI m_woodText;
    public TextMeshProUGUI m_rockText;

    private void Start()
    {
        m_woodHeld = 0;
        m_rockHeld = 0;
    }
}
