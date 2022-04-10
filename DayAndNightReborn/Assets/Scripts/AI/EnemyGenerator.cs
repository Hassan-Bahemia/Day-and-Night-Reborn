using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Public")] 
    public int m_density;
    public GameObject m_enemyPrefab;
    public int m_enemySpawned;
    public float m_timeToSpawn;
    public float m_defaultTimeToSpawn;
    public List<GameObject> m_enemyList;
    public Transform m_playerTransform;
    [SerializeField] private GameObjectiveManager m_GOM;

    // Start is called before the first frame update
    void Start()
    {
        m_playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        m_timeToSpawn = m_defaultTimeToSpawn;
        m_GOM = GameObject.Find("GameManager").GetComponent<GameObjectiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        m_timeToSpawn -= Time.deltaTime;
        
        if (m_timeToSpawn <= 0 && m_enemySpawned == 0 && !m_GOM.m_isObjectiveThreeComplete)
        {
            for (int i = 0; i < m_density; i++)
            {
                SpawnPrefab();
                m_enemySpawned++;
            }
            m_timeToSpawn = m_defaultTimeToSpawn;
        }
        else
        {
            m_enemyList.Clear();
        }

        if (m_timeToSpawn <= 0 && m_enemySpawned == 0 && m_GOM.m_isFinalBossKilled)
        {
            for (int i = 0; i < m_density; i++)
            {
                SpawnPrefab();
                m_enemySpawned++;
            }
            m_timeToSpawn = m_defaultTimeToSpawn;
        }
        else
        {
            m_enemyList.Clear();
        }
    }

    public void SpawnPrefab()
    {
        RaycastHit hit;

        if (Physics.Raycast(new Vector3(m_playerTransform.position.x + Random.Range(-60, 150), m_playerTransform.position.y + 100, m_playerTransform.position.z + Random.Range(-60, 150)), Vector3.down, out hit, Mathf.Infinity))
        {
            GameObject clone = Instantiate(m_enemyPrefab, hit.point, Quaternion.identity);
            clone.transform.parent = transform;
            m_enemyList.Add(clone);
        }
    }
}
