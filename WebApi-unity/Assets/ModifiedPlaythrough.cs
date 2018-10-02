using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class ModifiedPlaythrough : MonoBehaviour
{
    public List<Player> characters;
    
    public ModifiedPlaythrough pt;

    // Use this for initialization
    void Start()
    {
        Player[] allObjects = FindObjectsOfType<Player>();
        
        foreach (Player character in allObjects)
        {
            Player c = character.GetComponent<Player>(); ;
            characters.Add(c);
        }

       // string json = JsonUtility.ToJson(characters);
      //  StartCoroutine(Upload(characters));

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Upload()
    {
       // Playthrough pt = this;
        string json = JsonUtility.ToJson(pt);

        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        Dictionary<string, string> headers = new Dictionary<string, string>();

        WWWForm form = new WWWForm();

        WWW putRequest = new WWW("http://localhost:5000/api/Playthroughs", bodyRaw, headers);

        yield return putRequest;

        if(string.IsNullOrEmpty (putRequest.error))
        {
            Debug.Log("upload complete");
            print("Upload complete!");
        }
        else
        {
            print(putRequest.error);
        }


        /*


        UnityWebRequest www = UnityWebRequest.Post(url, bodyRaw);
        UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        */
    }

    public IEnumerator Get()
    {
        string url = "http://localhost:5000/api/playthroughs"/*tähän lisäksi vielä controllerin nimi*/;
        WWW www = new WWW(url);
        while(!www.isDone)
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
        yield return w.SendWebRequest();
    }
}
