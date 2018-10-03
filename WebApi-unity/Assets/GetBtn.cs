using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using UnityEngine.Networking;

public class GetBtn : MonoBehaviour {

    public Button getBtn;
    public Playthrough pt;
    public PlayThroughController controller;
    // Use this for initialization
    void Start()
    {
        controller = FindObjectOfType<PlayThroughController>();
        getBtn = getBtn.GetComponent<Button>();

        getBtn.onClick.AddListener(GetClick);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetClick()
    {
        StartCoroutine(this.Get());

        Debug.Log("get clicked");
    }
    public IEnumerator Get()
    {
        string url = "http://localhost:5000/api/playthroughs";
        WWW www = new WWW(url);
        while(!www.isDone)
        {
            yield return null;
        }

        if (string.IsNullOrEmpty(www.error))
        {
            controller.allPlaythroughs.Clear();
            var bytesToString = System.Text.Encoding.UTF8.GetString(www.bytes);
            PTListObj ptList = JsonConvert.DeserializeObject<PTListObj>(bytesToString);
            foreach (Playthrough item in ptList.PTList)
            {
                controller.allPlaythroughs.Add(item);
            } 
            /*Tallenna tässä arvot jotka tulee get requestina*/
        }
        else
        {
            print(www.error);
        }
        UnityWebRequest w = UnityWebRequest.Get(url);
        yield return w.SendWebRequest();
    }
}
