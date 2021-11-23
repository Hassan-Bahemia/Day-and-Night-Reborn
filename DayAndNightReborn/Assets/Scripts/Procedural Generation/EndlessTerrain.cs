using System;
using System.Collections.Generic;
using UnityEngine;

namespace Procedural_Generation
{
    public class EndlessTerrain : MonoBehaviour
    {
        private const float viewerMoveThresholdForChunkUpdate = 25f;

        private const float sqrViewerMoveThresholdForChunkUpdate = viewerMoveThresholdForChunkUpdate * viewerMoveThresholdForChunkUpdate;
        
        public LODInfo[] detailLevels;
        public static float maxViewDist;
        
        public Transform viewer;
        public Material mapMaterial;

        public static Vector2 viewerPostion;
        private Vector2 viewerPositionOld;
        static MapGenerator mapGenerator;
        private int chunkSize;
        private int chunksVisibleInViewDist;
        
        Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
        List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();

        private void Start()
        {
            mapGenerator = FindObjectOfType<MapGenerator>();

            maxViewDist = detailLevels[detailLevels.Length - 1].visibleDistThreshold;
            chunkSize = MapGenerator.mapChunkSize - 1;
            chunksVisibleInViewDist = Mathf.RoundToInt(maxViewDist / chunkSize);
            
            UpdateVisibleChunks();
        }

        private void Update()
        {
            viewerPostion = new Vector2(viewer.position.x, viewer.position.z);

            if ((viewerPositionOld - viewerPostion).sqrMagnitude > sqrViewerMoveThresholdForChunkUpdate) {
                viewerPositionOld = viewerPostion;
                UpdateVisibleChunks();
            }
        }

        void UpdateVisibleChunks()
        {
            for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++) {
                terrainChunksVisibleLastUpdate[i].SetVisible(false);
            }
            terrainChunksVisibleLastUpdate.Clear();
            
            int currentChunkCoordX = Mathf.RoundToInt(viewerPostion.x / chunkSize);
            int currentChunkCoordY = Mathf.RoundToInt(viewerPostion.y / chunkSize);

            for (int yOffset = -chunksVisibleInViewDist; yOffset <= chunksVisibleInViewDist; yOffset++) {
                for (int xOffset = -chunksVisibleInViewDist; xOffset <= chunksVisibleInViewDist; xOffset++) {
                    Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                    if (terrainChunkDictionary.ContainsKey(viewedChunkCoord)) {
                        terrainChunkDictionary[viewedChunkCoord].UpdateTerrainChunk();
                        if (terrainChunkDictionary[viewedChunkCoord].IsVisible()) {
                            terrainChunksVisibleLastUpdate.Add(terrainChunkDictionary[viewedChunkCoord]);
                        }
                    } else {
                        terrainChunkDictionary.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord, chunkSize, detailLevels, transform, mapMaterial));
                    }
                }
            }
        }

        public class TerrainChunk
        {
            private GameObject meshObject;
            private Vector2 position;
            private Bounds bounds;

            private MeshRenderer meshRenderer;
            private MeshFilter meshFilter;

            private LODInfo[] detailLevels;
            private LODMesh[] lodMeshes;

            private MapData mapData;
            private bool mapDataReceived;
            private int previousLODIndex = -1;

            public TerrainChunk(Vector2 coord, int size, LODInfo[] detailLevels, Transform parent, Material material)
            {
                this.detailLevels = detailLevels;
                
                position = coord * size;
                bounds = new Bounds(position, Vector2.one * size);
                Vector3 positionV3 = new Vector3(position.x, 0, position.y);
                
                meshObject = new GameObject("Terrain Chunk");
                meshRenderer = meshObject.AddComponent<MeshRenderer>();
                meshFilter = meshObject.AddComponent<MeshFilter>();
                meshRenderer.material = material;
                
                meshObject.transform.position = positionV3;
                meshObject.transform.parent = parent;
                SetVisible(false);
                
                lodMeshes = new LODMesh[detailLevels.Length];
                for (int i = 0; i < detailLevels.Length; i++) {
                    lodMeshes[i] = new LODMesh(detailLevels[i].lod, UpdateTerrainChunk);
                }
                
                mapGenerator.RequestMapData(position, OnMapDataRecieved);
            }

            void OnMapDataRecieved(MapData mapData)
            {
                this.mapData = mapData;
                mapDataReceived = true;

                Texture2D texture = MapTextureGenerator.TextureFromColourMap(mapData.colourMap, MapGenerator.mapChunkSize, MapGenerator.mapChunkSize);
                meshRenderer.material.mainTexture = texture;

                UpdateTerrainChunk();
            }

            public void UpdateTerrainChunk()
            {
                if (mapDataReceived) {
                    float viewerDistFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPostion));
                    bool visible = viewerDistFromNearestEdge <= maxViewDist;

                    if (visible)
                    {
                        int lodIndex = 0;

                        for (int i = 0; i < detailLevels.Length - 1; i++)
                        {
                            if (viewerDistFromNearestEdge > detailLevels[i].visibleDistThreshold)
                            {
                                lodIndex = i + 1;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (lodIndex != previousLODIndex)
                        {
                            LODMesh lodMesh = lodMeshes[lodIndex];
                            if (lodMesh.hasMesh)
                            {
                                previousLODIndex = lodIndex;
                                meshFilter.mesh = lodMesh.mesh;
                            }
                            else if (!lodMesh.hasRequestedMesh)
                            {
                                lodMesh.RequestMesh(mapData);
                            }
                        }
                    }

                    SetVisible(visible);
                }
            }

            public void SetVisible(bool visible)
            {
                meshObject.SetActive(visible);
            }

            public bool IsVisible()
            {
                return meshObject.activeSelf;
            }
        }

        class LODMesh
        {
            public Mesh mesh;
            public bool hasRequestedMesh;
            public bool hasMesh;
            private int lod;
            private System.Action updateCallback;

            public LODMesh(int lod, System.Action updateCallback)
            {
                this.lod = lod;
                this.updateCallback = updateCallback;
            }

            void OnMeshDataRecieved(MeshData meshData)
            {
                mesh = meshData.CreateMesh();
                hasMesh = true;

                updateCallback();
            }
            
            public void RequestMesh(MapData mapData)
            {
                hasRequestedMesh = true;
                mapGenerator.RequestMeshData(mapData, lod, OnMeshDataRecieved);
            }
        }
        
        [System.Serializable]
        public struct LODInfo
        {
            public int lod;
            public float visibleDistThreshold;
        }
    }
}
