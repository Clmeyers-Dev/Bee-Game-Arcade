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
    public GameObject parent;
    public TestMovment player;
    void Start()
    {
       // parent = GetComponentInParent<GameObject>();
       player = GetComponentInParent<TestMovment>();
    }
    public void  Update()
    {
        if(timer <=0){
        if(Input.GetKey(KeyCode.Space)){

  var shot =   Instantiate(bullet,firepoint.position,Quaternion.Euler(parent.transform.localEulerAngles.x,parent.transform.localEulerAngles.y,parent.transform.localEulerAngles.z) );
            //shot.GetComponent<Projectile>().setSpeed( player.getSpeed() + 20);
            timer = fireSpeed;
        }
        }else{
            timer -= Time.deltaTime;
        }
    }
}
