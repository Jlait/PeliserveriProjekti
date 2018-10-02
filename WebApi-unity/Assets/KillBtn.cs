using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillBtn : MonoBehaviour {

    // Use this for initialization
    public Button killBtn;
    public Player player;
    public int kills;


	void Start () {
        killBtn = killBtn.GetComponent<Button>();
        player = player.GetComponent<Player>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        killBtn.onClick.AddListener(KillOnClick); 
    }
	
	// Update is called once per frame
	void Update () {

	}

    // Increase kills
    void KillOnClick()
    {
        player.kills += 1; 
        Debug.Log(player.kills);
    }
}
