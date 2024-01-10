using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public SceneEnum sceneToLoad;

    // This method is intended to be called when a button triggers a scene load
    public void LoadSceneWithButton()
    {
        SceneManager.LoadSceneAsync(sceneToLoad.ToString());
    }
}

// An enumeration to represent different scenes in the game
public enum SceneEnum
{
    End_Scene,
    Game_Scene,
    Start_Menu,
    Testing_Scene,
    Options
}
