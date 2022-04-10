using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [Header("Private")] 
    [SerializeField] private bool m_inRange;
    [SerializeField] private GameObject m_displayInteractMSG;
    [SerializeField] private GameObjectiveManager m_GOM;

    // Start is called before the first frame update
    void Start()
    {
        m_displayInteractMSG.SetActive(false);
        m_GOM = FindObjectOfType<GameObjectiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && m_inRange)
        {
            Interact();
        }
    }

    void LoadScene()
    {
        if (m_GOM.m_isFinalBossKilled)
        {
            m_GOM.EndGame();
        }
    }

    private void Interact()
    {
        LoadScene();
        m_displayInteractMSG.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_inRange = true;
            m_displayInteractMSG.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_inRange = false;
            m_displayInteractMSG.SetActive(false);
        }
    }

    public void DisplayMSG(GameObject display)
    {
        m_displayInteractMSG = display;
    }
}
