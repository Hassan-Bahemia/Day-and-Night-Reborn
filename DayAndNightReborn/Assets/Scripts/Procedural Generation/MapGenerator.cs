using UnityEngine;

namespace Procedural_Generation
{
    public class MapGenerator : MonoBehaviour
    {
        public int mapWidth;
        public int mapHeight;
        public float noiseScale;

        public bool autoUpdate;

        public void GenerateMap()
        {
            float[,] noiseMap = NoiseMap.GenerateNoiseMap(mapWidth, mapHeight, noiseScale);

            MapDisplay display = FindObjectOfType<MapDisplay>();
            display.DrawNoiseMap(noiseMap);
        }
    }
}
