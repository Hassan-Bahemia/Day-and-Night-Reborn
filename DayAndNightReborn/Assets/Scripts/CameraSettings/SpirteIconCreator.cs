using UnityEditor;
using UnityEngine;

namespace CameraSettings
{
    public class SpirteIconCreator : MonoBehaviour
    {
        private Camera camera;

        public string pathFolder;

        void TakeScreenshot(string fullpath)
        {
            if (camera == null)
            {
                camera = GetComponent<UnityEngine.Camera>();
            }
        
            RenderTexture rt = new RenderTexture(256, 256, 24);
            camera.targetTexture = rt;
            Texture2D screenShot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
            camera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0,0,256,256),0, 0);
            camera.targetTexture = null;
            RenderTexture.active = null;

            if (Application.isEditor)
            {
                DestroyImmediate(rt);
            }
            else
            {
                Destroy(rt);
            }

            byte[] bytes = screenShot.EncodeToPNG();
            System.IO.File.WriteAllBytes(fullpath, bytes);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }
    }
}
