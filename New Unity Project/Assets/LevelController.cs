using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public bool finished = false;
    public bool hasPlayerBase = false;
    public int difficulty;
    public bool started = false;
    public Vector3 BasePosition { get; internal set; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateRoutes()
    {
        
    }
    public bool HasStarted()
    {
        return started;
    }
    public void StartLevel()
    {
        started = true;
    }
}
