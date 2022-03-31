using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Public")] 
    public Animator m_axeSwing;
    public Animator m_pickAxeSwing;
    public Animator m_swordSwing;
    
    [Header("Private")] 
    [SerializeField] private Transform[] m_tools;
    [SerializeField] private KeyCode[] m_keys;
    [SerializeField] private float m_switchTime;
    [SerializeField] private int m_selectedWeapon;
    [SerializeField] private float m_timeSinceLastSwitch;
    [SerializeField] private float m_timeSinceSwung;
    
    // Start is called before the first frame update
    void Start()
    {
        SetTools();
        Select(m_selectedWeapon);

        m_timeSinceLastSwitch = 0f;
        m_timeSinceSwung = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = m_selectedWeapon;

        for (int i = 0; i < m_keys.Length; i++) {
            if (Input.GetKeyDown(m_keys[i]) && m_timeSinceLastSwitch >= m_switchTime) {
                m_selectedWeapon = i;
            }
        }
        
        if(previousSelectedWeapon != m_selectedWeapon) Select(m_selectedWeapon);

        m_timeSinceLastSwitch += Time.deltaTime;
        m_timeSinceSwung += Time.deltaTime;
    }

    public void SwingTool()
    {
        if (m_selectedWeapon == 0 && m_axeSwing.GetCurrentAnimatorStateInfo(0).IsName("Default") && m_timeSinceSwung > 2.25f) {
            m_axeSwing.SetBool("Swing", true);
            m_timeSinceSwung = 0f;
        }
        else
        {
            m_axeSwing.SetBool("Swing", false);
        }
        if (m_selectedWeapon == 1 && m_pickAxeSwing.GetCurrentAnimatorStateInfo(0).IsName("Default") && m_timeSinceSwung > 2.25f) {
            m_pickAxeSwing.SetBool("Swing", true);
            m_timeSinceSwung = 0f;
        }
        else
        {
            m_pickAxeSwing.SetBool("Swing", false);
        }
        if (m_selectedWeapon == 2 && m_swordSwing.GetCurrentAnimatorStateInfo(0).IsName("Default") && m_timeSinceSwung > 2.25f) {
            m_swordSwing.SetBool("Swing", true);
            m_timeSinceSwung = 0f;
        }
        else
        {
            m_swordSwing.SetBool("Swing", false);
        }
    }

    private void SetTools()
    {
        m_tools = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++) {
            m_tools[i] = transform.GetChild(i);
        }
        
        if(m_keys == null) m_keys = new KeyCode[m_tools.Length];
    }

    private void Select(int weaponIndex)
    {
        for (int i = 0; i < m_tools.Length; i++) {
            m_tools[i].gameObject.SetActive(i == weaponIndex);
        }

        m_timeSinceLastSwitch = 0f;

        OnWeaponSelected();
    }

    private void OnWeaponSelected()
    {
        print("Selected new tool");
    }
}
