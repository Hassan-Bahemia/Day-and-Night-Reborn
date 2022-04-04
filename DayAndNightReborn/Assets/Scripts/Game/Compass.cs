using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] private Transform m_player;
    [SerializeField] private Vector3 m_dir;

    private void Update()
    {
        m_dir.z = m_player.eulerAngles.y;
        transform.localEulerAngles = m_dir;
    }
}
