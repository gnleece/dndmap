using SFB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer output;

    public void Button_LoadImage()
    {
        Debug.Log("Load image");
        var paths = StandaloneFileBrowser.OpenFilePanel("Title", "", "jpg", false);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
    }

    private IEnumerator OutputRoutine(string url)
    {
        var loader = new WWW(url);
        yield return loader;
        output.sprite = Sprite.Create(loader.texture, new Rect(0,0, loader.texture.width, loader.texture.height), new Vector2(0.5f, 0.5f));
    }
}
