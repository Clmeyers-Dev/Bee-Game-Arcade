using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    public float curTime;
    
    public GameObject objectToSpawn;
    public BoxCollider2D spawnbox;
    public float spawnPoint;
    public float max;
    
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    public float offset =5;
    void Update()
    {
          max =Random.Range(spawnbox.bounds.min.x,spawnbox.bounds.max.x) ;
        if(curTime >= spawnRate){
            spawnPoint = max;
            //spawn
            Instantiate(objectToSpawn,new Vector3 (spawnPoint,transform.position.y,0),Quaternion.Euler(0,0,180));
            curTime = 0;
        }else{
            curTime += Time.deltaTime;
        }
    }
}
