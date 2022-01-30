using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]
    //private float upAndDown = 6;
    [SerializeField]
    private float downwardSpeed = 6;
    [SerializeField]
    private float LeftAndRight = 6;
   // [SerializeField]
   // private float moveSpeedIncrement = .1f;
   // [SerializeField]
   // private float SpeedCap = 20f;
    public GameObject left;
    public GameObject right;
     public GameObject top;
    public GameObject bottom;
    public float score;
    public TextMeshProUGUI scoreText;
    public AudioSource audioSource;
    void Start()
    {

    }
    void Update()
    {
        scoreText .text = score+"";
       // if (downwardSpeed < SpeedCap)
         //   downwardSpeed += moveSpeedIncrement * Time.deltaTime;
    }
    public float getSpeed()
    {
        return downwardSpeed;
    }
    public void slow()
    {
        downwardSpeed = downwardSpeed / 2;
    }
    // Update is called once per frame
    [SerializeField]
    private float Rightoffset;
    [SerializeField]
    private float LeftOffset;
      [SerializeField]
    private float topOffset;
    [SerializeField]
    private float BottomOffset;
    public float modifier = 1;
    public void addPoints(float p){
        score += (p*modifier);
    }
    void FixedUpdate()
    {
        //   transform.Translate(Vector3.down*downwardSpeed*Time.deltaTime);
        
        if (Input.GetKey(KeyCode.W) && transform.position.y < top.transform.position.y+topOffset)// downwardSpeed > 6)
        {
            // downwardSpeed -=(upAndDown*2)*Time.deltaTime;
            transform.Translate(Vector3.up * LeftAndRight * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > bottom.transform.position.y+BottomOffset )//downwardSpeed < SpeedCap)
        {

            //downwardSpeed +=upAndDown*Time.deltaTime;
            transform.Translate(Vector3.down * LeftAndRight * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A)&&transform.position.x>left.transform.position.x+LeftOffset)
        {
            transform.Translate(Vector3.left * LeftAndRight * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)&&transform.position.x<right.transform.position.x+Rightoffset)
        {
            transform.Translate(-Vector3.left * LeftAndRight * Time.deltaTime);
        }
    }
}
