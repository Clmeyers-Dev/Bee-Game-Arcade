using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

     [SerializeField]
    private float fireangle;
    [SerializeField]
    private float fireSpeed = 0.5f;
    [SerializeField]
    private float timer;
    public Transform firepoint;
    [SerializeField]
    private GameObject bullet;

    public void  Update()
    {
        if(timer <=0){
        if(Input.GetKey(KeyCode.Space)){

            Instantiate(bullet,firepoint.position,Quaternion.Euler(new Vector3(0,0,fireangle)));
            timer = fireSpeed;
        }
        }else{
            timer -= Time.deltaTime;
        }
    }
}
