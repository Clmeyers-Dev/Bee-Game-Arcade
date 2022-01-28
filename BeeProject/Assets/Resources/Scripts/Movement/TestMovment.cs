using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovment : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float upAndDown = 6;
    [SerializeField]
    private float downwardSpeed = 6;
     [SerializeField]
    private float LeftAndRight = 6;
    [SerializeField]
    private float moveSpeedIncrement =.1f;
    [SerializeField]
    private float SpeedCap = 20f;

    void Start()
    {
        
    }
    void  Update()
    {
    if(downwardSpeed <SpeedCap)
        downwardSpeed+=moveSpeedIncrement *Time.deltaTime;
    }
    public void slow(){
        downwardSpeed = downwardSpeed/2;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down*downwardSpeed*Time.deltaTime);
        if(Input.GetKey(KeyCode.UpArrow)&&downwardSpeed>6){
            downwardSpeed -=(upAndDown*2)*Time.deltaTime;
         //  transform.Translate(Vector3.up*upAndDown*Time.deltaTime);
       }
        if(Input.GetKey(KeyCode.DownArrow)&&downwardSpeed<SpeedCap){

             downwardSpeed +=upAndDown*Time.deltaTime;
           // transform.Translate(Vector3.down*upAndDown*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left*LeftAndRight*Time.deltaTime);
        }
         if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(-Vector3.left*LeftAndRight*Time.deltaTime);
        }
    }
}
