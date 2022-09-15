using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class timeTeller : MonoBehaviour
{
    // public GameObject timeTextObject;

    // // Start is called before the first frame update
    // void Start()
    // { 
    // InvokeRepeating("UpdateTime", 0f, 10f);    
    // }

    
    // void UpdateTime()
    // {
    // timeTextObject.GetComponent<TextMeshPro>().text = System.DateTime.Now.ToString("h:mm tt");
        
    // }

    public GameObject timeTextObject;
        // add your personal API key after APPID= and before &units=
        string url = "http://worldtimeapi.org/api/timezone/America/Argentina/Salta";
   
    void Start()
    {

    // refresh every 20 seconds

       InvokeRepeating("GetDataFromWeb", 0f, 20f);
   }

   void GetDataFromWeb()
   {

       StartCoroutine(GetRequest(url));
   }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.result ==  UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

                // this code will NOT fail gracefully, so make sure you have
                // your API key before running or you will get an error

            	// grab the current temperature and simplify it if needed

            	int startTime = webRequest.downloadHandler.text.IndexOf("datetime",0);
                startTime += 22; // skip all unnecessary text
            	// int endTime = webRequest.downloadHandler.text.IndexOf("T",startTime);
                string localTime = webRequest.downloadHandler.text.Substring(startTime,5);
                Debug.Log(":\nstartTime: " + startTime);
                Debug.Log(":\nlocal time found: " + localTime);
				
                int hour = int.Parse(localTime.Substring(0,2));
                Debug.Log(":\nhour found: " + hour);
                if(hour < 12) { // add AM or PM depending
                    timeTextObject.GetComponent<TextMeshPro>().text = "" + localTime.ToString() + " AM";
                }
                else{
                    hour -= 12; // set to 12 hour format
                    string tempString = localTime.Substring(2, 3);
                    localTime = "" + hour + tempString;
                    timeTextObject.GetComponent<TextMeshPro>().text = "" + localTime.ToString() + " PM";
                     }
            }
        }
    }
}