using UnityEngine;

namespace Procedural_Generation
{
    public static class NoiseMap
    {
        public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
        {
            float[,] noiseMap = new float[mapWidth, mapHeight];
            
            System.Random prng = new System.Random(seed);
            Vector2[] octaveOffsets = new Vector2[octaves];
            for (var i = 0; i < octaves; i++) {
                float offsetX = prng.Next(-100000, 100000) + offset.x;
                float offsetY = prng.Next(-100000, 100000) + offset.y;
                octaveOffsets[i] = new Vector2(offsetX, offsetY);
            }

            if (scale <= 0)
                scale = 0.0001f;

            float maxNoiseHeight = float.MinValue;
            float minNoiseHeight = float.MaxValue;

            float halfWidth = mapWidth / 2f;
            float halfHeight = mapHeight / 2f;
            
            for (var y = 0; y < mapHeight; y++) {
                for (var x = 0; x < mapWidth; x++) {
                    float amplitude = 1;
                    float frequency = 1;
                    float noiseHeight = 0;
                    
                    for (var i = 0; i < octaves; i++) {
                        var sampleX = (x - halfWidth) / scale * frequency + octaveOffsets[i].x;
                        var sampleY = (y - halfHeight) / scale * frequency + octaveOffsets[i].y;
                        var perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                        noiseHeight += perlinValue * amplitude;

                        amplitude *= persistance;
                        frequency *= lacunarity;
                    }

                    if (noiseHeight > maxNoiseHeight)
                        maxNoiseHeight = noiseHeight;
                    else if (noiseHeight < minNoiseHeight)
                        minNoiseHeight = noiseHeight;
                    
                    noiseMap[x, y] = noiseHeight;
                }
            }

            for (var y = 0; y < mapHeight; y++) {
                for (var x = 0; x < mapWidth; x++) {
                    noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
                }
            }

            return noiseMap;
        }
    }
}
