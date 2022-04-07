using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameObjectiveManager : MonoBehaviour
{
    [Header("Private")]
    [SerializeField] private int m_maxWoodsNeeded;
    [SerializeField] private int m_maxStonesNeeded;
    [SerializeField] private bool m_isFinalBossKilled;
    [SerializeField] private bool m_canBoatBeCrafted;
    [SerializeField] private bool m_canPlayerFinish;
    [SerializeField] private bool m_isObjectiveOneComplete;
    [SerializeField] private bool m_isObjectiveTwoComplete;
    [SerializeField] private bool m_isObjectiveThreeComplete;
    [SerializeField] private bool m_isObjectiveFourComplete;
    [SerializeField] private PlayerInventory m_playerInventory;
    
    [Header("Boat Settings")]
    [SerializeField] private GameObject m_boat;
    [SerializeField] private Transform[] m_boatSpawns;

    // Start is called before the first frame update
    void Start()
    {
        m_playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        m_isObjectiveOneComplete = false;
        m_isObjectiveTwoComplete = false;
        m_isObjectiveThreeComplete = false;
        m_isObjectiveFourComplete = false;
        m_canPlayerFinish = false;
        m_canBoatBeCrafted = false;
        m_boat = Instantiate(m_boat, m_boatSpawns[Random.Range(0, m_boatSpawns.Length)].position, Quaternion.identity);
        m_boat.transform.localScale = new Vector3(15, 15, 15);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfObjectiveOneComplete();
        CheckIfObjectiveTwoComplete();
        BoatCanBeBuilt();
        SpawnFinalBoss();
        FinishGame();
    }

    void CheckIfObjectiveOneComplete()
    {
        if (m_playerInventory.m_woodHeld >= m_maxWoodsNeeded)
        {
            m_isObjectiveOneComplete = true;
        }
    }
    
    void CheckIfObjectiveTwoComplete()
    {
        if (m_playerInventory.m_rockHeld >= m_maxStonesNeeded)
        {
            m_isObjectiveTwoComplete = true;
        }
    }

    void BoatCanBeBuilt()
    {
        if (m_isObjectiveOneComplete && m_isObjectiveTwoComplete)
        {
            m_canBoatBeCrafted = true;
            if (m_canBoatBeCrafted)
            {
                m_isObjectiveThreeComplete = true;
            }
        }
    }

    void SpawnFinalBoss()
    {
        if (m_isObjectiveThreeComplete)
        {
             
        }
    }

    void FinishGame()
    {
        if (m_isObjectiveOneComplete && m_isObjectiveTwoComplete && m_isObjectiveThreeComplete && m_isObjectiveFourComplete && m_isFinalBossKilled)
        {
            
        }
    }
}
