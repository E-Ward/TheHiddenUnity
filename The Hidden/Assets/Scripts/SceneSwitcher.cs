using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public void GotoMenuScene()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void GotoLevelSelectScene()
    {
        SceneManager.LoadScene("Level_Select");
    }
    public void GotoMainLevel()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void OpenURL()
    {
        Application.OpenURL("http://Youtube.com/");
        Debug.Log("is this working?");
    }
}
