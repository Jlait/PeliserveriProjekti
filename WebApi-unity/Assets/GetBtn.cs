using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBtn : MonoBehaviour {

    public Button getBtn;
    public ModifiedPlaythrough pt;
    public PlayThroughController controller;
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
        pt.Get();

        Debug.Log("get clicked");
    }
}
