using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManagerScript : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    // Only specifying the sceneName or sceneBuildIndex will load the scene with the Single mode
    public void LoadNextLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
