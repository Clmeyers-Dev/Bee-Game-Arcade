using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] healthBars = new GameObject [3];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loseHealth(){
        for(int i = 0; i < healthBars.Length;i++){
            if(healthBars[i].activeSelf){
                healthBars[i].SetActive(false);
                return;
            }
        }
    }
    public void gainHealth(){
        for(int i = healthBars.Length-1;i>=0;i--){
            if(!healthBars[i].activeSelf){
                healthBars[i].SetActive(true);
                return;
            }
        }
    }
    public int getNumberOfHealth(){
        int count=0;
       for(int i = 0; i < healthBars.Length;i++){
           if(healthBars[i].activeSelf){
               count++;
           }
       }

        return count;
    }
}
