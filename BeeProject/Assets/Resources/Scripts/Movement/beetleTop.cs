using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beetleTop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float Vertspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.up*Vertspeed*Time.deltaTime);
    }
}
