using SFB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer output = null;

    public void Button_LoadImage()
    {
        Debug.Log("Load image");
        var paths = StandaloneFileBrowser.OpenFilePanel("Title", "", "jpg", false);
        if (paths.Length > 0)
        {
            StartCoroutine(LoadMapTexture(new System.Uri(paths[0]).AbsoluteUri));
        }
    }

    public void Button_SetGrid()
    {
        Debug.Log("Set grid");
    }

    private IEnumerator LoadMapTexture(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                var texture = DownloadHandlerTexture.GetContent(uwr);
                output.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
        }
    }
}
