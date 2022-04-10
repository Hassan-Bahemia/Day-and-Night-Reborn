using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameObjectiveManager : MonoBehaviour
{
    [Header("Private")]
    [SerializeField] private int m_maxWoodsNeeded;
    [SerializeField] private int m_maxStonesNeeded;
    public bool m_isFinalBossKilled;
    [SerializeField] private bool m_hasBoatBeenCrafted;
    [SerializeField] private bool m_canPlayerFinish;
    [SerializeField] private bool m_isObjectiveOneComplete;
    [SerializeField] private bool m_isObjectiveTwoComplete;
    public bool m_isObjectiveThreeComplete;
    [SerializeField] private PlayerInventory m_playerInventory;
    [SerializeField] private TextMeshProUGUI m_escapeText;
    
    [Header("Boat Settings")]
    [SerializeField] private GameObject m_boat;
    [SerializeField] private Transform[] m_boatSpawns;
    [SerializeField] private TextMeshProUGUI m_boatText;
    [SerializeField] private GameObject m_displayInteractMSG;

    [Header("Boss")] 
    [SerializeField] private GameObject m_boss;
    [SerializeField] private Transform m_playerTransform;
    [SerializeField] private TextMeshProUGUI m_bossText;
    [SerializeField] private Animator m_bossTextAnim;
    public bool m_bossIsSpawned;

    // Start is called before the first frame update
    void Start()
    {
        m_playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        m_playerInventory.m_woodText.color = Color.red;
        m_playerInventory.m_rockText.color = Color.red;
        m_bossText.color = Color.red;
        m_boatText.color = Color.red;
        m_escapeText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        FinishGame();
        CheckIfObjectiveOneComplete();
        CheckIfObjectiveTwoComplete();
        BuildBoat();

        if (m_isObjectiveThreeComplete)
        {
            SpawnBoss();
            m_isObjectiveThreeComplete = false;
        }

        m_playerInventory.m_woodText.text = $"1.Wood Collected: {m_playerInventory.m_woodHeld} / {m_maxWoodsNeeded}";
        m_playerInventory.m_rockText.text = $"2.Rock Collected: {m_playerInventory.m_rockHeld} / {m_maxStonesNeeded}";
    }

    void CheckIfObjectiveOneComplete()
    {
        if (m_hasBoatBeenCrafted)
            return;
        
        if (m_playerInventory.m_woodHeld >= m_maxWoodsNeeded)
        {
            m_isObjectiveOneComplete = true;
            m_playerInventory.m_woodText.color = Color.green;
        }
    }
    
    void CheckIfObjectiveTwoComplete()
    {
        if (m_hasBoatBeenCrafted)
            return;
        
        if (m_playerInventory.m_rockHeld >= m_maxStonesNeeded)
        {
            m_isObjectiveTwoComplete = true;
            m_playerInventory.m_rockText.color = Color.green;
        }
    }

    void BuildBoat()
    {
        if (!m_isObjectiveOneComplete || !m_isObjectiveTwoComplete)
            return;
        print("building boat");
        m_isObjectiveOneComplete = false;
        m_isObjectiveTwoComplete = false;
        m_hasBoatBeenCrafted = true;
        GameObject clone2 = Instantiate(m_boat, m_boatSpawns[Random.Range(0, m_boatSpawns.Length)].position, Quaternion.identity);
        clone2.GetComponent<Boat>().DisplayMSG(m_displayInteractMSG);
        m_boat.transform.localScale = new Vector3(15, 15, 15);
        m_isObjectiveThreeComplete = true;
        m_boatText.color = Color.green;
    }

    void CanSpawnFinalBoss()
    {
        if (m_isObjectiveThreeComplete)
        {
            RaycastHit hit;

            if (Physics.Raycast(new Vector3(m_playerTransform.position.x + Random.Range(-60, 150), m_playerTransform.position.y + 100, m_playerTransform.position.z + Random.Range(-60, 150)), Vector3.down, out hit, Mathf.Infinity))
            {
                GameObject clone = Instantiate(m_boss, hit.point, Quaternion.identity);
            }
            m_bossTextAnim.SetBool("Show", true);
            m_bossTextAnim.SetBool("Hide", false);
        }
    }

    void SpawnBoss()
    {
        print("hello");
        CanSpawnFinalBoss();
        m_bossIsSpawned = true;
    }

    void FinishGame()
    {
        if (m_isFinalBossKilled)
        {
            m_canPlayerFinish = true;
            m_bossText.color = Color.green;
            m_escapeText.color = Color.green;
            m_bossTextAnim.SetBool("Hide", true);
            m_bossTextAnim.SetBool("Show", false);
        }
    }

    public void EndGame()
    {
        if (m_isFinalBossKilled)
        {
            SceneManager.LoadScene("Win_Scene");
        }
    }
}
