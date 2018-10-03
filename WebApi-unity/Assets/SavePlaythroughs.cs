using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System;
using System.Text;

public class SavePlaythroughs : MonoBehaviour {

	PlayThroughController controller;
	private void Start() {
		controller = FindObjectOfType<PlayThroughController>();
	}
	// Use this for initialization
	public void UpSaves(){
		StartCoroutine(Put());
	}
	 IEnumerator Put()
    {
		/* PTListObj ptlistobj = new PTListObj();
		foreach (Playthrough item in controller.allPlaythroughs)
		{
			ptlistobj.PTList.Add(item);
		}
        // Playthrough pt = this;
        string json = JsonUtility.ToJson(ptlistobj);

        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "Application/json");

        WWWForm form = new WWWForm();

        WWW putRequest = new WWW("http://localhost:5000/api/Playthroughs", bodyRaw, headers); */
		string json = JsonUtility.ToJson(controller.selectedPlayThrough, true);
		byte[] myData = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest www = UnityWebRequest.Put("http://localhost:5000/api/Playthroughs/"+controller.selectedPlayThrough.id.ToString(), myData);
		//www.chunkedTransfer = false;
		www.SetRequestHeader("Content-Type", "application/json");
    	www.SetRequestHeader ("Accept", "text/json");
	    //yield return www.SendWebRequest();
		yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("upload complete");
            print("Upload complete!");
        }
        else
        {
            print(www.error);
        }

        Debug.Log("update clicked");
    }
}
