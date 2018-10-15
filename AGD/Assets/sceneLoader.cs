using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneLoader : MonoBehaviour {

    public static sceneLoader startGame { set; get; }
    private void Awake()
    {
        startGame = this;
        Load("level 1");
        Load("level 2");
        //Load("MailboxIndicator");
    }

    public void Load(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

  /*  public void unLoad(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.UnLoadSceneAsync(sceneName);
    }
    */ 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
