using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_Wasp : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 start;
 //[SerializeField]
    //private float freq = 5f;
    //[SerializeField]
   // private float mag = 5f;
    //[SerializeField]
  //  private float offset = 0f;
    [SerializeField]
    float speed = 5f;
      [SerializeField]
    float Vertspeed = 5f;

    [SerializeField]
    float maxTime;
    [SerializeField]
    float time;
    public bool movingRight;
    void Start()
    {
        start = transform.position;
        maxTime = Random.Range(1,6);
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.down*Vertspeed*Time.deltaTime);
      // transform.position =  start +new Vector3(Mathf.Sin(Time.time),0.0f, 0.0f);
       if(time >= maxTime){
           movingRight = !movingRight;
           time = 0;
       }else{
           time += Time.deltaTime;
       }
     if(movingRight){
         transform.Translate(-Vector3.left * speed * Time.deltaTime);
     }else{
         transform.Translate(Vector3.left*speed*Time.deltaTime);
     }
    }
}
