using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour {

    public List<FollowPath> UnitsModels;
    public List<TDPath> Paths;
    bool waitValidPath = true;
    public List<GameObject> instances;
    public static OpponentController instance;
   
    // Use this for initialization
    void Start () {
        //RetrieveRoute();
        instance = this;
        foreach(FollowPath fp in UnitsModels )
        {
            fp.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
    void ValidStart()
    {
        SpawnWave(2, 5, 0, 2, Paths[0]);
        SpawnWave(1, 5, 14, 2, Paths[0]);
        SpawnWave(0, 5, 28, 2, Paths[0]);
    }
    void Update () {
		if(waitValidPath)
        {
            if (Paths[0].GetCount() == 0)
                return;
            waitValidPath = false;
            ValidStart();
        }
	}

    void SpawnWave(int waveType, int num, int startTime, float freq, TDPath path)
    {
        for (int i = 0; i < num; i++)
        {
            FollowPath newEnemy = GameObject.Instantiate(UnitsModels[waveType], path.GetPoint(0), Quaternion.identity);
            newEnemy.startTime = startTime+ freq * i;
            newEnemy.gameObject.SetActive(true);
            instances.Add(newEnemy.gameObject);
        }
    }
}
