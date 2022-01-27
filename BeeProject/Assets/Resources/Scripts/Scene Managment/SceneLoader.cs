using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneEnum sceneToLoad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadWithbutton(){
       SceneManager.LoadSceneAsync(sceneToLoad.ToString());
       // Load.LoadThis(sceneToLoad);
    }

}
public enum SceneEnum
{
    End_Scene,
    Game_Scene,
    Start_Menu,
    Testing_Scene,
    Options



}

