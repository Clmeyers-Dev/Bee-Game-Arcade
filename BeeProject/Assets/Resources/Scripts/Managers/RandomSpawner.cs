using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // Start is called before the first frame update
     public float MaxTime;
     public float minTime;
    public float curTime;
    public float randomTime;
    
    public GameObject objectToSpawn;
    public BoxCollider2D spawnbox;
    public float spawnPoint;
    
    void Start()
    {
        randomTime = Random.Range(minTime,MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(curTime<=randomTime){
            curTime+=Time.deltaTime;
        }else{
            spawn();
            curTime = 0;
            randomTime = Random.Range(minTime,MaxTime);
        }
    }
    void spawn(){
      float  max =Random.Range(spawnbox.bounds.min.x,spawnbox.bounds.max.x) ;
            spawnPoint = max;
            Instantiate(objectToSpawn,new Vector3 (spawnPoint,transform.position.y,0),Quaternion.Euler(0,0,0));
    }
}
