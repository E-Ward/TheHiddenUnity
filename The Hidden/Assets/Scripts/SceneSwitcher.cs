using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public GameObject characterSelect;

    public GameObject CharacterSelectCamera;

    public GameObject Hidden;
    public GameObject IRIS;

    public GameObject Controls;

    public GameObject Hiddencanvas;
    public GameObject IRIScanvas;

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

    public void CharacterSelectHidden()
    {
        characterSelect.SetActive(false);
        CharacterSelectCamera.SetActive(false);
        Hidden.SetActive(true);
        IRIS.SetActive(false);
        IRIScanvas.SetActive(false);
    }

    public void CharacterSelectIRIS()
    {
        characterSelect.SetActive(false);
        CharacterSelectCamera.SetActive(false);
        IRIS.SetActive(true);
        Hidden.SetActive(false);
        Hiddencanvas.SetActive(false);
    }

    public void ControlsEnable()
    {
        Controls.SetActive(true); 
    }

    public void ControlsDisable()
    {
        Controls.SetActive(false);
    }
}
