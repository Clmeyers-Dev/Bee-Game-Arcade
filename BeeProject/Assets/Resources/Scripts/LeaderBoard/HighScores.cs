using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class HighScores : MonoBehaviour
{
  const string privateCode ="q5pBxwr2MkyUuheMwepD1Q4cwgczQNTkqTvGYfmaplrQ";
  const string publicCode ="61f91bfd8f40bb1058bf16e0";
  const string webURL ="http://dreamlo.com/lb/";
    void Awake()
    {
        addNewHighscore("Christopher",50);
        addNewHighscore("Jack",150);
        addNewHighscore("Joe",10050);
    }
     public void addNewHighscore(string username ,int score){
      StartCoroutine(UploadNewHighScore(username,score));
  }
  IEnumerator UploadNewHighScore(string  username, int score){
      UnityWebRequest www = new UnityWebRequest(webURL +privateCode+"/add/"+UnityWebRequest.EscapeURL(username)+"/"+score);
      yield return www;

      if(string.IsNullOrEmpty(www.error)){
          Debug.Log("Upload Successful");
      }else{
          Debug.Log("error Uploading "+ www.error);
      }
  }
 
}
