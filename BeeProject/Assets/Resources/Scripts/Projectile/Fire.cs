using System;
using System.Collections;
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

    public PlayerManager player;
    
    public float burstFireSpeed = 1;

    void Start()
    {
        player = GetComponentInParent<PlayerManager>();
    }

    void Update()
    {
        if (timer <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                var shot = Instantiate(bullet, firepoint.position, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + fireangle));
              //  GetComponent<AudioSource>().PlayOneShot(sound);
              //  timer = currentSpeed;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    internal void SetFireSpeed(object fireSpeedA)
    {
       // fireSpeed = fireSpeedA;
    }

}
