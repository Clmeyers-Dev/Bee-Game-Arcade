using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers : MonoBehaviour
{
    [SerializeField] private GameObject spreadShot;
    private bool spreadShotFlag;
    private bool honeyLaserFlag;
    private bool burstShotFlag;
    public AudioSource[] laserSounds = new AudioSource[3];
    private PlayerManager playerMan;
    [SerializeField] private AudioClip modifierSound;
    private float curTime;
    [SerializeField] private float modifierTime;
    [SerializeField] private GameObject[] cannons = new GameObject[2];
    public GameObject mainLaser;
    public GameObject[] sideLasers = new GameObject[2];
    public GameObject mainGun;

    void Start()
    {
        playerMan = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {
        if (curTime <= 0)
        {
            spreadShot.SetActive(false);
            DeactivateLasers();
            spreadShotFlag = false;
            honeyLaserFlag = false;
            burstShotFlag = false;
          //  mainCannonFire.SetFireSpeed(mainCannonFire.FireSpeed);
            for (int i = 0; i < laserSounds.Length; i++)
            {
                laserSounds[i].Stop();
            }
          //  playerMan.PlayerMainGunFire.SetBullet(normalShot);
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }

    public void ActivateSpreadShot()
    {
        spreadShot.SetActive(true);
        spreadShotFlag = true;
        honeyLaserFlag = false;
        burstShotFlag = false;
       // playerMan.PlayerMainGunFire.SetBullet(normalShot);
        curTime = modifierTime;
    }

    public GameObject[] cannonGuns = new GameObject[2];

    public void ActivateHoneyLaser()
    {
        mainGun.SetActive(false);
        spreadShot.SetActive(false);
        spreadShotFlag = false;
        honeyLaserFlag = true;
        burstShotFlag = false;
        mainLaser.SetActive(true);
        for (int i = 0; i < 2; i++)
        {
            cannonGuns[i].SetActive(false);
            if (sideLasers[i].activeSelf == false && cannons[i].activeSelf == true)
            {
                sideLasers[i].SetActive(true);
            }
        }
        curTime = modifierTime;
    }

    public GameObject burstShot;
    public GameObject normalShot;
    public Fire mainCannonFire;

    public void ActivateBurstShot()
    {
        spreadShot.SetActive(false);
        DeactivateLasers();
        spreadShotFlag = false;
        honeyLaserFlag = false;
        burstShotFlag = true;
        //mainCannonFire.SetFireSpeed(mainCannonFire.BurstFireSpeed);
       // playerMan.PlayerMainGunFire.SetBullet(burstShot);
        curTime = modifierTime;
    }

    public void ActivateCannons()
    {
        for (int i = 0; i < 2; i++)
        {
            if (!cannons[i].activeSelf)
            {
                cannons[i].SetActive(true);
            }
            if (honeyLaserFlag)
            {
                ActivateHoneyLaser();
            }
        }
    }

    public void DeactivateLasers()
    {
        mainLaser.SetActive(false);
        mainLaser.GetComponent<LaserTut>().audioSource.Stop();
        mainGun.SetActive(true);
        honeyLaserFlag = false;
        for (int i = 0; i < 2; i++)
        {
            if (sideLasers[i].activeSelf && cannons[i].activeSelf)
            {
                sideLasers[i].SetActive(false);
                sideLasers[i].GetComponent<LaserTut>().audioSource.Stop();
                cannonGuns[i].SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spread")
        {
            playerMan.audioSource.PlayOneShot(modifierSound);
            playerMan.AddPoints(500);
            ActivateSpreadShot();
            DeactivateLasers();
            Destroy(other.gameObject);
        }
        if (other.tag == "Laser")
        {
            playerMan.audioSource.PlayOneShot(modifierSound);
            playerMan.AddPoints(500);
            ActivateHoneyLaser();
            Destroy(other.gameObject);
        }
        if (other.tag == "Burst")
        {
            playerMan.audioSource.PlayOneShot(modifierSound);
            playerMan.AddPoints(500);
            ActivateBurstShot();
            DeactivateLasers();
            Destroy(other.gameObject);
        }
        if (other.tag == "cannon")
        {
            playerMan.audioSource.PlayOneShot(modifierSound);
            playerMan.AddPoints(500);
            ActivateCannons();
            if (honeyLaserFlag)
            {
                ActivateHoneyLaser();
            }
            Destroy(other.gameObject);
        }
    }
}
