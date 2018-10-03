using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using UnityEngine.Networking;

public class GetBtn : MonoBehaviour {

    public Button getBtn;
    public Playthrough pt;
    public PlayThroughController controller;
    public List<PlayThrough> pts;

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
<<<<<<< HEAD
        StartCoroutine(Get());
    }

    public IEnumerator Get()
    {
        string url = "http://localhost:5000/api/playthroughs"/*tähän lisäksi vielä controllerin nimi*/;
        WWW www = new WWW(url);
        while (!www.isDone)
        {
            yield return null;
        }

        if (string.IsNullOrEmpty(www.error))
        {
            /*Tallenna tässä arvot jotka tulee get requestina*/
        }
        else
        {
            print(www.error);
        }

        UnityWebRequest w = UnityWebRequest.Get(url);
        // Show results as text
        Debug.Log(w.downloadHandler.text);

        // Or retrieve results as binary data
        byte[] results = w.downloadHandler.data;

        if (results == null)
            yield return null;

        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream(results))
        {
            object obj = bf.Deserialize(ms);
            pts = (List<PlayThrough>)obj;
        }
=======
        StartCoroutine(this.Get());
>>>>>>> Zimbe-patch-1

        yield return w.SendWebRequest();
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
