using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayThrough : MonoBehaviour
{

    public Guid guid;
    public List<Player> playerList;

    //public ModifiedPlaythrough pt;

    // Use this for initializationee
    void Start()
    {
        Player[] allObjects = FindObjectsOfType<Player>();

        foreach (Player character in allObjects)
        {
            Player c = character.GetComponent<Player>(); ;
            playerList.Add(c);
        }


    }
}