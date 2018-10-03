using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

[Serializable]
public class PTListObj{
    public List<Playthrough> PTList {get;set;}
}

[Serializable]
public class Playthrough
{
    //public List<Player> players{get;set;}
    [SerializeField]
    public Player[] players;//{get;set;}
    
    public Guid id{get;set;}
    public DateTime CreationTime{get;set;}
    

    // Use this for initializationee
    void Start()
    {
        /* Player[] allObjects = FindObjectsOfType<Player>();
        
        foreach (Player character in allObjects)
        {
            Player c = character.GetComponent<Player>(); ;
            players.Add(c);
            
        } */

       // string json = JsonUtility.ToJson(characters);
      //  StartCoroutine(Upload(characters));

    }

    // Update is called once per frame
    void Update()
    {

    }

   /*  public IEnumerator Upload()
    {
       // Playthrough pt = this;
        string json = JsonUtility.ToJson(this);

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
        
    } */

    
}
