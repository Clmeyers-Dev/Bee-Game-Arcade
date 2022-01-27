using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform firepoint;
    [SerializeField]
    private GameObject bullet;

    public void  Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            Instantiate(bullet,firepoint.position,Quaternion.identity);
        }
    }
}
