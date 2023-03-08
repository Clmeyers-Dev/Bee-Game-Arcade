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
    public AudioSource[] laserSounds = new AudioSource[3];
    private PlayerManager playerMan;
    [SerializeField]
    private AudioClip modifierSound;
    private float curTime;
    [SerializeField]
    private float modifierTime;
    [SerializeField]
    GameObject[] cannons = new GameObject[2];
    public GameObject mainLaser;
   public GameObject[] sideLasers = new GameObject[2];
    void Start()
    {
        playerMan = FindObjectOfType<PlayerManager>();
    }
    public GameObject mainGun;
    // Update is called once per frame
    void Update()
    {
        if(curTime <=0){
        spreadShot.SetActive(false);
        DeActivateLasers();
        spreadShotFlag = false;
        HoneyLaserFlag = false;
        burstShotFlag = false;
        mainCannonFire.setFireSpeed(mainCannonFire.fireSpeed);
        for(int i = 0;i < laserSounds.Length;i++){
            laserSounds[i].Stop();
        }
         playerMan.playerMainGunFire.setBullet(normalShot);
        }else{
            curTime -=Time.deltaTime;
        }
    }
    public void activateSpreadShot(){
        spreadShot.SetActive(true);
        spreadShotFlag = true;
        HoneyLaserFlag = false;
        burstShotFlag = false;
         playerMan.playerMainGunFire.setBullet(normalShot);
        curTime = modifierTime;
    }
    public GameObject[] cannonGuns= new GameObject[2];
    public void activateHoneyLaser(){
        mainGun.SetActive(false);
        spreadShot.SetActive(false);
        spreadShotFlag = false;
        HoneyLaserFlag = true;
        burstShotFlag = false;
         mainLaser.SetActive(true);
        for(int i = 0; i < 2;i++){
            cannonGuns[i].SetActive(false);
            if(sideLasers[i].activeSelf==false&& cannons[i].activeSelf==true){
                sideLasers[i].SetActive(true);
                
            }
        }
         curTime = modifierTime;
    

    }
    public GameObject burstShot;
    public GameObject normalShot;
    public Fire mainCannonFire;
    public void activateBurstShot(){
        spreadShot.SetActive(false);
        DeActivateLasers();
        spreadShotFlag = false;
        HoneyLaserFlag = false;
        burstShotFlag = true;
        mainCannonFire.setFireSpeed(mainCannonFire.burstFireSpeed);
       playerMan.playerMainGunFire.setBullet(burstShot);
         curTime = modifierTime;

    }
    public void activateCannons(){
          for(int i = 0; i < 2;i++){
            if(!cannons[i].activeSelf){
                cannons[i].SetActive(true);
                
            }
            if(HoneyLaserFlag){
                activateHoneyLaser();
            }
        }
    }
    public void DeActivateLasers(){
         mainLaser.SetActive(false);
         mainLaser.GetComponent<LaserTut>().audioSource.Stop();
         mainGun.SetActive(true);
         HoneyLaserFlag = false;
        for(int i = 0; i < 2;i++){
            if(sideLasers[i].activeSelf&& cannons[i].activeSelf){
                sideLasers[i].SetActive(false);
                sideLasers[i].GetComponent<LaserTut>().audioSource.Stop();
                 cannonGuns[i] .SetActive(true);
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
        DeActivateLasers();
        Destroy(other.gameObject);
    }
    if(other.tag == "Laser"){
        playerMan.audioSource.PlayOneShot(modifierSound);
         playerMan.addPoints(500);
        activateHoneyLaser();
           Destroy(other.gameObject);
    }
    if(other.tag == "Burst"){
        playerMan.audioSource.PlayOneShot(modifierSound);
         playerMan.addPoints(500);
        activateBurstShot();
        DeActivateLasers();
        Destroy(other.gameObject);
    }
    if(other.tag == "cannon"){
        playerMan.audioSource.PlayOneShot(modifierSound);
         playerMan.addPoints(500);
        Debug.Log("cannons active");
        activateCannons();
        if(HoneyLaserFlag){
            activateHoneyLaser();
        }
        Destroy(other.gameObject);
      
    }
}
}
