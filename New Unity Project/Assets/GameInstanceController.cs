using Mapbox.Unity.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstanceController : MonoBehaviour {

    public AbstractMap map;
    public OpponentController opponent;
    public PlayerController player;

    public GameObject LoadingScreen;
    public bool leveLReady = false;
	// Use this for initialization
    void Awake()
    {
        LoadingScreen.SetActive(true);
    }
	void Start () {
        Debug.Log("Start:" + Time.fixedTime);

    }

    // Update is called once per frame
    void Update () {
        if (map.Root != null)
        {
           if(map.Root.childCount != 0 && leveLReady==false)
            {
                Debug.Log("Root:" + map.Root.childCount + " :" + Time.fixedTime);
                leveLReady = true;
            }
        }
        if(leveLReady)
        {
            LoadingScreen.SetActive(false);
        }
	}
}
