using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectiveManager : MonoBehaviour
{
    [Header("Private")]
    [SerializeField] private int m_maxWoodsNeeded;
    [SerializeField] private int m_maxStonesNeeded;
    [SerializeField] private bool m_isFinalBossKilled;
    [SerializeField] private bool m_canBoatBeSpawned;
    [SerializeField] private bool m_canPlayerFinish;
    [SerializeField] private bool m_isObjectiveOneComplete;
    [SerializeField] private bool m_isObjectiveTwoComplete;
    [SerializeField] private bool m_isObjectiveThreeComplete;
    [SerializeField] private bool m_isObjectiveFourComplete;
    [SerializeField] private PlayerInventory m_playerInventory;


    // Start is called before the first frame update
    void Start()
    {
        m_playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        m_isObjectiveOneComplete = false;
        m_isObjectiveTwoComplete = false;
        m_isObjectiveThreeComplete = false;
        m_isObjectiveFourComplete = false;
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
            m_canBoatBeSpawned = true;
            m_isObjectiveThreeComplete = true;
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
