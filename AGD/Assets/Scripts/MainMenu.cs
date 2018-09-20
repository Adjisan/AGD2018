using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button ButtonPlay;
    public Button ButtonLevelSelect;
    public Button ButtonExit;
    public string newGameSceneName;

    public GameObject loadLevelMenu; 
    public void NewGame()
    {
        SceneManager.LoadScene(newGameSceneName);
    }

    public void LevelSelect()
    {
        loadLevelMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }


}
