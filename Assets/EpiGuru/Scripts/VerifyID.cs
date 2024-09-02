using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Globalization;
using UnityEngine.SceneManagement;

public class VerifyID : MonoBehaviour
{
    public class LocationInfo
    {
        public string ip, city, region, country, loc, org, postal, timezone;
    }

    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://ipinfo.io/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            LocationInfo locationInfo = JsonUtility.FromJson<LocationInfo>(json);
            

            if(locationInfo.country == "UA")
                SceneManager.LoadScene("MenuScene");
            else
                Application.OpenURL("https://x.com/home");
                
            Debug.Log("Country: " + locationInfo.country);
        }
        else
        {
            Debug.Log("Error");
        }
    }
}
