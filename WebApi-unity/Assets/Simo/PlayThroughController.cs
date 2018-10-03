using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayThroughController : MonoBehaviour {

	public List<PlayThrough> allPlaythroughs = new List<PlayThrough>(); //Put all playthroughs from parameterless get to here
	public GameObject playThroughList;
	public PlayThrough selectedPlayThrough;
	public Text selectedGuid;
	public List<Button> buttonList = new List<Button>();
	public bool updateInProgress; //Guarantees that generation is not interrupted
	public Text warriorKills, warriorDeaths, rangerKills, rangerDeaths, wizardKills, wizardDeaths;

	private void UpdateTexts() {
		warriorKills.text = "Kills: "+selectedPlayThrough.playerList[0].kills.ToString();
		rangerKills.text = "Kills: "+selectedPlayThrough.playerList[1].kills.ToString();
		wizardKills.text = "Kills: "+selectedPlayThrough.playerList[2].kills.ToString();
		warriorDeaths.text = "Deaths: "+selectedPlayThrough.playerList[0].deaths.ToString();
		rangerDeaths.text = "Deaths: "+selectedPlayThrough.playerList[1].deaths.ToString();
		wizardDeaths.text = "Deaths: "+selectedPlayThrough.playerList[2].deaths.ToString();
	}

	//Updates the onscreen list from controller's list
	public void UpdatePlayThroughList(){
		if(updateInProgress){
			return;
		}
		updateInProgress = true;
		foreach (var item in buttonList)
		{
			Destroy(item);
		}
		foreach (var item in allPlaythroughs)
		{
			Button btn = Resources.Load("Button") as Button;
			buttonList.Add(btn);
			btn.onClick.AddListener(() => SelectPlayThrough(allPlaythroughs.IndexOf(item)));
		}
		selectedPlayThrough = allPlaythroughs[0];
		UpdateTexts();
		updateInProgress = false;
	}
	//Selects a playthrough from list and highlights it
	public void SelectPlayThrough(int number){
		selectedPlayThrough = allPlaythroughs[number];
		selectedGuid.text = selectedPlayThrough.guid.ToString();
		UpdateTexts();
	}
	public void addKills(int playerNbr){
		selectedPlayThrough.playerList[playerNbr].kills++;
		UpdateTexts();
	}
	public void addDeaths(int playerNbr){
		selectedPlayThrough.playerList[playerNbr].deaths++;
		UpdateTexts();
	}
}
/*
[Serializable]
public class PlayThrough{
	public Guid guid;
	public List<Player> playerList = new List<Player>();
}
*/