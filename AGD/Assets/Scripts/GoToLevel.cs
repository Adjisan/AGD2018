using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour {


    public void Level(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void CallMenu()
    {
        FindObjectOfType<GameManagerScript>().gameHasEnded = false;
        FindObjectOfType<GameManagerScript>().CallMenu();

    }
}