using UnityEngine;

namespace Procedural_Generation
{
    public static class NoiseMap
    {
        public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale)
        {
            float[,] noiseMap = new float[mapWidth, mapHeight];

            if (scale <= 0)
            {
                scale = 0.0001f;
            }

            for (var y = 0; y < mapHeight; y++)
            {
                for (var x = 0; x < mapWidth; x++)
                {
                    var sampleX = x / scale;
                    var sampleY = y / scale;
                    var perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                    noiseMap[x, y] = perlinValue;
                }
            }

            return noiseMap;
        }
    }
}
