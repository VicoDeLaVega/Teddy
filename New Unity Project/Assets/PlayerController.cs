using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int BaseLifePoints = 1000;
    public GameObject battleGround;
    public GameObject TowerType0;

    public static PlayerController instance;
    public static PlayerController GetPlayerController()
    {
        return instance;
    }
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
 	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnTower(Vector2 screenPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (battleGround.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject go = GameObject.Instantiate(TowerType0, hit.point+new Vector3(0,20,0),Quaternion.identity);
            Debug.Log("Instantiate at" + hit.point);

        }
    } 
}
