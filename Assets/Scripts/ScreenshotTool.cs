using System;
using UnityEngine;

public class ScreenshotTool : MonoBehaviour
{
    private Vector3 _defaultPosition = new Vector3(0, 0, 5);
    private Vector3 _defaultRotation = new Vector3(-15, -45, 15);
    private Vector3 _defaultScale = new Vector3(1, 1, 1);
    private Camera _cam;
    private void Start()
    {
        MekeScreenshotCamera();
        takeTextureFromObj(Color.clear, Screen.width, Screen.height);
    }

    public void MekeScreenshotCamera()
    {
       var screenshotCam = new GameObject("Screenshot Camera");
       var cam = screenshotCam.AddComponent<Camera>();
       cam.cullingMask = 1 << 31;
       cam.orthographic = true;
       cam.orthographicSize = 1;
       cam.clearFlags = CameraClearFlags.SolidColor;
       cam.backgroundColor = Color.clear;
       cam.nearClipPlane = 0.1f;
       cam.enabled = false;
       _cam = cam;
    }

    private Texture2D takeTextureFromObj(Color backgroundColor, int width, int height)
    {
        _cam.backgroundColor = backgroundColor;
        _cam.targetTexture = RenderTexture.GetTemporary(width, height, 24);
        _cam.Render();
        var previouslyActiveRenderTexture = RenderTexture.active;
        RenderTexture.active = _cam.targetTexture;
        var texture = new Texture2D(_cam.targetTexture.width, _cam.targetTexture.height, TextureFormat.ARGB32, false);
        texture.ReadPixels(new Rect(0, 0, _cam.targetTexture.width, _cam.targetTexture.height), 0, 0);
        texture.Apply(false);
        RenderTexture.active = previouslyActiveRenderTexture;
        _cam.targetTexture = null;
        RenderTexture.ReleaseTemporary(_cam.targetTexture);
        return texture;
    }
}