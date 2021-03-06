﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayThroughController : MonoBehaviour {

	public List<Playthrough> allPlaythroughs; //= new List<Playthrough>(); //Put all playthroughs from parameterless get to here
	public GameObject playThroughList;
	public Playthrough selectedPlayThrough;
	public Text selectedGuid;
	public List<Button> buttonList = new List<Button>();
	public bool updateInProgress; //Guarantees that generation is not interrupted
	public Text warriorKills, warriorDeaths, rangerKills, rangerDeaths, wizardKills, wizardDeaths;

	private void UpdateTexts() {
		warriorKills.text = "Kills: "+selectedPlayThrough.players[0].kills.ToString();
		rangerKills.text = "Kills: "+selectedPlayThrough.players[1].kills.ToString();
		wizardKills.text = "Kills: "+selectedPlayThrough.players[2].kills.ToString();
		warriorDeaths.text = "Deaths: "+selectedPlayThrough.players[0].deaths.ToString();
		rangerDeaths.text = "Deaths: "+selectedPlayThrough.players[1].deaths.ToString();
		wizardDeaths.text = "Deaths: "+selectedPlayThrough.players[2].deaths.ToString();
	}

	//Updates the onscreen list from controller's list
	public void UpdatePlayThroughList(){
		if(updateInProgress){
			return;
		}
		if(allPlaythroughs.Count == 0){
			return;
		}
		updateInProgress = true;
		foreach (var item in buttonList)
		{
			if(item == null){
				return;
			}
			Destroy(item.gameObject);
		}
		foreach (var item in allPlaythroughs)
		{
			GameObject btn = Instantiate(Resources.Load("Button") as GameObject,new Vector3(0,0,0),Quaternion.identity,playThroughList.transform);
			btn.GetComponentInChildren<Text>().text = "Playthrough " + allPlaythroughs.IndexOf(item).ToString();
			buttonList.Add(btn.GetComponent<Button>());
			btn.GetComponent<Button>().onClick.AddListener(() => SelectPlayThrough(allPlaythroughs.IndexOf(item)));
			Debug.Log("Button with parameter: "+allPlaythroughs.IndexOf(item));
		}
		selectedPlayThrough = allPlaythroughs[0];
		UpdateTexts();
		updateInProgress = false;
	}
	//Selects a playthrough from list and highlights it
	public void SelectPlayThrough(int number){
		selectedPlayThrough = allPlaythroughs[number];
		selectedGuid.text = selectedPlayThrough.id.ToString();
		UpdateTexts();
	}
	public void addKills(int playerNbr){
		selectedPlayThrough.players[playerNbr].kills++;
		UpdateTexts();
	}
	public void addDeaths(int playerNbr){
		selectedPlayThrough.players[playerNbr].deaths++;
		UpdateTexts();
	}
}
