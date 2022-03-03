using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ProceduralObjectPlacement : MonoBehaviour
{
    [SerializeField] private GameObject m_prefab;

    [Header("Raycast Settings")] 
    [SerializeField] private int m_density;

    [Space] 
    
    [SerializeField] private float m_minHeight;
    [SerializeField] private float m_maxHeight;
    [SerializeField] private Vector2 m_xRange;
    [SerializeField] private Vector2 m_zRange;

    [Header("Prefab Variation Settings")] 
    [SerializeField, Range(0, 1)] private float m_rotateTowardsNormal;
    [SerializeField] private Vector2 m_rotationRange;
    [SerializeField] private Vector3 m_minScale;
    [SerializeField] private Vector3 m_maxScale;

#if UNITY_EDITOR
    
    public void Generate()
    {
        ClearPrefabs();

        for (int i = 0; i < m_density; i++) {
            float sampleX = Random.Range(m_xRange.x, m_xRange.y);
            float sampleY = Random.Range(m_zRange.x, m_zRange.y);
            Vector3 rayStart = new Vector3(sampleX, m_maxHeight, sampleY);

            if (!Physics.Raycast(rayStart, Vector3.down, out RaycastHit hit, Mathf.Infinity)) {
                continue;
            }

            if (hit.point.y < m_minHeight) {
                continue;
            }

            GameObject clonedObject = (GameObject)Instantiate(this.m_prefab, transform);
            clonedObject.transform.position = hit.point;
            clonedObject.transform.Rotate(Vector3.up, Random.Range(m_rotationRange.x, m_rotationRange.y), Space.Self);
            clonedObject.transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.FromToRotation(clonedObject.transform.up, hit.normal), m_rotateTowardsNormal);
            clonedObject.transform.localScale = new Vector3(
                Random.Range(m_minScale.x, m_maxScale.x),
                Random.Range(m_minScale.y, m_maxScale.y),
                Random.Range(m_minScale.z, m_maxScale.z));
        }
    }
    
    public void ClearPrefabs()
    {
        while (transform.childCount != 0) {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

#endif
}
