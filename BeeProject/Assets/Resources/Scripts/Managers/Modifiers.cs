using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spreadShot;
    private bool spreadShotFlag;
    private bool HoneyLaserFlag;
    private bool burstShotFlag;
    private PlayerManager playerMan;
    [SerializeField]
    private AudioClip modifierSound;
    private float curTime;
    [SerializeField]
    private float modifierTime;
    [SerializeField]
    GameObject[] cannons = new GameObject[2];
    void Start()
    {
        playerMan = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(curTime <=0){
        spreadShot.SetActive(false);
        spreadShotFlag = false;
        HoneyLaserFlag = false;
        burstShotFlag = false;
        }else{
            curTime -=Time.deltaTime;
        }
    }
    public void activateSpreadShot(){
        spreadShot.SetActive(true);
        spreadShotFlag = true;
        HoneyLaserFlag = false;
        burstShotFlag = false;
        curTime = modifierTime;
    }
    public void activateHoneyLaser(){
        spreadShot.SetActive(false);
        spreadShotFlag = true;
        HoneyLaserFlag = false;
        burstShotFlag = false;
         curTime = modifierTime;
    

    }
    public void activateBurstShot(){
        spreadShot.SetActive(false);
        spreadShotFlag = true;
        HoneyLaserFlag = false;
        burstShotFlag = false;
         curTime = modifierTime;

    }
    public void activateCannons(){
          for(int i = 0; i < 2;i++){
            if(!cannons[i].activeSelf){
                cannons[i].SetActive(true);
            }
        }
    }
void OnTriggerEnter2D(Collider2D other)
{
    
   // Debug.Log("hit");   
    if(other.tag == "Spread"){
        playerMan.audioSource.PlayOneShot(modifierSound);
        playerMan.addPoints(500);
        Debug.Log("spread active");
        activateSpreadShot();
        Destroy(other.gameObject);
    }
    if(other.tag == "Laser"){
        playerMan.audioSource.PlayOneShot(modifierSound);
         playerMan.addPoints(500);
        activateHoneyLaser();
    }
    if(other.tag == "Burst"){
        playerMan.audioSource.PlayOneShot(modifierSound);
         playerMan.addPoints(500);
        activateBurstShot();
    }
    if(other.tag == "cannon"){
         playerMan.addPoints(500);
        Debug.Log("cannons active");
        activateCannons();
        Destroy(other.gameObject);
      
    }
}
}
