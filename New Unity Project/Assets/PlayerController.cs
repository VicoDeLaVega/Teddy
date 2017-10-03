using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int BaseLifePoints = 1000;
    public int ConstructionPoints = 1000;
    
    public GameObject battleGround;
    public GameObject SpotTarget;

    public static PlayerController instance;
    public static PlayerController GetPlayerController()
    {
        return instance;
    }
    void Awake()
    {
        instance = this;
        SpotTarget = GameObject.Find("SpotTarget");
    }
    // Use this for initialization
    void Start () {
 	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PopMessage(int i)
    {
        Debug.Log("funds insuffisants");
    }

    internal void PlaceSpotTarget(Vector3 mousePosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (battleGround.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
        {
            SpotTarget.transform.position = hit.point;
            //   /*GameObject go = */GameObject.Instantiate(TowerType0, hit.point+new Vector3(0,20,0),Quaternion.identity);
            //   Debug.Log("Instantiate at" + hit.point);


        }
    }
}
