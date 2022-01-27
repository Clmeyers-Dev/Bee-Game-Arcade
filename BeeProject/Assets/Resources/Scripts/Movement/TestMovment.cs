using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovment : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float movementSpeed = 6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.up*movementSpeed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.down*movementSpeed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left*movementSpeed*Time.deltaTime);
        }
         if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(-Vector3.left*movementSpeed*Time.deltaTime);
        }
    }
}
