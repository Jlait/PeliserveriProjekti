using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathBtn : MonoBehaviour {

    public Button deathBtn;
    public Player player;
    public int deaths;

    // Use this for initialization
    void Start () {
        deathBtn = deathBtn.GetComponent<Button>();
        player = player.GetComponent<Player>();

        deathBtn.onClick.AddListener(DeathOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Increase deaths
    void DeathOnClick()
    {
       
        player.deaths += 1;
        Debug.Log(player.deaths);
    }
}
