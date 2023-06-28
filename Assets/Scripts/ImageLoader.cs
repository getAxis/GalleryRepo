using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    // переменные
    // variables

    [SerializeField] int imageAmount;
    private string imageURL = "http://data.ikppbb.com/test-task-unity-data/pics/";
    public RawImage rawImage;
    [SerializeField] GameObject _im;


    [SerializeField] GameObject imagePref;
    [SerializeField] GameObject grid;
    private GameObject[] imageArr;


    void Start()
    {
        imageArr = new GameObject[imageAmount];
        // инициализация 66 картинок
        // initialization of 66 images
        for(int i =0; i< imageAmount; i++)
        {
            GameObject newImage = createImage(i);
            
            string num = Convert.ToString(i + 1);


            RawImage curImage = newImage.GetComponent<RawImage>();

            StartCoroutine(LoadImageFromServer(num, curImage));
            
        }
    }


    // Корутина которая устанавливает соединение с сервером, проверяет его наличие и в случае удачного соединения назначает текстуру объекту
    // A coroutine that establishes a connection to the server, checks for its existence and, in case of a successful connection,
    // assigns a texture to the object
    private IEnumerator LoadImageFromServer(string _num, RawImage image)
    {
        string neededURL = imageURL+_num+".jpg";
        UnityWebRequest url = UnityWebRequestTexture.GetTexture(neededURL);
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

    // функция которая создает префаб картинки
    // function that creates an image prefab
    public GameObject createImage(int num)
    {
        GameObject newImage = Instantiate(imagePref, grid.transform.position, Quaternion.identity);
        newImage.transform.SetParent(grid.transform);
        newImage.gameObject.name = "Image" + (num + 1);
        return newImage;
    }
}
