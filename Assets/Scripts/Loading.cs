using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    // variables
    public Image Placefilter;
    public float loadingTime = 3f;
    public string sceneName = "Gallery";

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }


    // Функция которая реализуется в сцене "LoadScene", она проверяет загрузку сцены следующей сцены "Gallery" и управляет заполнением LoadBar 
    // A function that is implemented in the scene "LoadScene", it checks the loading of the scene of the next scene "Gallery"
    // and controls the filling of the LoadBar
    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress /0.9f);
            Placefilter.fillAmount = progress;

            if (progress >= 1f)
            {
                // Загрузка завершена
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
