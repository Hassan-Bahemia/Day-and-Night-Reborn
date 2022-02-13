using System;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class GenerateNavMesh : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface m_navMeshSurface;

        private void Start()
        {
            m_navMeshSurface = GetComponent<NavMeshSurface>();
            BuildNavMesh();
        }

        public void BuildNavMesh()
        {
            m_navMeshSurface.BuildNavMesh();
        }
    }
}
