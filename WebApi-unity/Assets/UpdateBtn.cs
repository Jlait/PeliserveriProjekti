using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBtn : MonoBehaviour {

    public Button updateBtn;
    public ModifiedPlaythrough pt;

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

        WWW putRequest = new WWW("http://localhost:5000/api/Playthroughs", bodyRaw, headers);

        yield return putRequest;

        if (string.IsNullOrEmpty(putRequest.error))
        {
            Debug.Log("upload complete");
            print("Upload complete!");
        }
        else
        {
            print(putRequest.error);
        }

        Debug.Log("update clicked");
    }
}
