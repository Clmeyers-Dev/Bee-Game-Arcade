using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GlobalControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static GlobalControl instance;
    [SerializeField]
    private float points;
    public PlayerManager playerManager;
    void Awake()
    {
        DontDestroyOnLoad (transform.gameObject);
        Application.targetFrameRate = 144;
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    playerManager = FindObjectOfType<PlayerManager>();
    }
    void  Update()
    {
        if(playerManager!=null){
            points = playerManager.score;
        }
    }
    
}
