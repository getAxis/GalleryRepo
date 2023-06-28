using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToImage : MonoBehaviour
{
    string num;
    string replaceWord = "Image";
    void Start()
    {
        num = gameObject.name.Replace(replaceWord, "");        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SavedData()
    {
        DataHolder.imageNum = num;
        SceneManager.LoadScene("ImageScene");        
    }
}
