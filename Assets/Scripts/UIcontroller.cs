using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public bool screenOrientationPortrait; 
    
    private void Awake()
    {
        if (screenOrientationPortrait == true)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else if (screenOrientationPortrait == false)
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
    public void LoadGalleryScene()
    {
        SceneManager.LoadScene("LoadScene");
    }
    public void ReturnToPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
