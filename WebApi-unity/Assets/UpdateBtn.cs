using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class UpdateBtn : MonoBehaviour {

    public Button updateBtn;
    public Playthrough pt;
    

    // Use this for initialization
    void Start () {
       
        updateBtn = updateBtn.GetComponent<Button>();

        updateBtn.onClick.AddListener(UpdateClick);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void UpdateClick()
    {
        StartCoroutine(Post());
    }

    IEnumerator Post()
    {
        // Playthrough pt = this;
        string json = JsonUtility.ToJson(pt);

        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "Application/json");

        WWWForm form = new WWWForm();

        WWW postRequest = new WWW("http://localhost:5000/api/Playthroughs", bodyRaw, headers);

        yield return postRequest;

        if (string.IsNullOrEmpty(postRequest.error))
        {
            Debug.Log("NewGame complete");
            print("NewGame complete!");
        }
        else
        {
            print(postRequest.error);
        }

        Debug.Log("NewGame clicked");
    }
}
