using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenShot : MonoBehaviour
{
    public void TakeScreenshot(string filePath)
    {
        StartCoroutine(CoroutineScreenshot(filePath));
    }

    private IEnumerator CoroutineScreenshot(string filePath) {
        yield return new WaitForEndOfFrame();

        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        Rect rect = new Rect(0, 0, width, height);
        tex.ReadPixels(rect, 0, 0);
        tex.Apply();

        byte[] bytes = tex.EncodeToPNG();

        System.IO.File.WriteAllBytes(filePath, bytes);
    }
}
