using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SingleImageLoad : MonoBehaviour
{
    private RawImage currentImage;
    private string imageURL;
    void Start()
    {
        currentImage = gameObject.GetComponent<RawImage>();
        imageURL = "http://data.ikppbb.com/test-task-unity-data/pics/" + DataHolder.imageNum+".jpg";
        StartCoroutine(LoadImageFromServer(imageURL, currentImage));
        
    }
    // загрузка выбранного изображения из сервера 
    private IEnumerator LoadImageFromServer(string _url, RawImage image)
    {
        UnityWebRequest url = UnityWebRequestTexture.GetTexture(_url);
        yield return url.SendWebRequest();
        if (url.result == UnityWebRequest.Result.ConnectionError || url.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error connections to the server");
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)url.downloadHandler).texture;
            image.texture = texture;
        }
    }
}
