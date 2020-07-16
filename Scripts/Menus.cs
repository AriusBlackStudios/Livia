using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public SaveToFile saveInfo;
   // public GameObject settingsMenu;


    public void NewGame()
    {
        saveInfo.NewSave();
        SceneManager.LoadScene("UnderWorld");
    }

    public void LoadGame()
    {
        saveInfo.Load();
        SceneManager.LoadScene("UnderWorld");
    }
    //public void Settings()
    //{
    //    settingsMenu.SetActive(true);
    //}
    public void QuitGame()
    {
        Application.Quit();
    }
}
