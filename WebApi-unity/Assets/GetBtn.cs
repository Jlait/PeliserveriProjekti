using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetBtn : MonoBehaviour {

    public Button getBtn;
    public ModifiedPlaythrough pt;
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

        yield return w.SendWebRequest();
    }
}
