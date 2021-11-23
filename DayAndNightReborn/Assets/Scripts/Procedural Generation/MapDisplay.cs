using UnityEngine;

namespace Procedural_Generation
{
    public class MapDisplay : MonoBehaviour
    {
        public Renderer textureRender;
        public MeshFilter MeshFilter;
        public MeshRenderer meshRenderer;
        
        public void DrawTexture(Texture2D texture)
        {
            textureRender.sharedMaterial.mainTexture = texture;
            textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height);
        }

        public void DrawMesh(MeshData meshData, Texture2D texture)
        {
            MeshFilter.sharedMesh = meshData.CreateMesh();
            meshRenderer.sharedMaterial.mainTexture = texture;
        }
    }
}
