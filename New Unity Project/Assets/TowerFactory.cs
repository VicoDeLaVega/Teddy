using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    public List<GameObject> towerTypes;
    public GameObject battleGround;
    public static TowerFactory instance;
    public static TowerFactory GetInstance()
    {
        return instance;
    }
    void Awake()
    {
        Utils.Log("TowerFactory:Awake");

        instance = this;
        towerTypes.Add(GameObject.Find("TowerType0"));
        towerTypes.Add(GameObject.Find("TowerType1"));
        towerTypes.Add(GameObject.Find("TowerType2"));
        towerTypes.Add(GameObject.Find("TowerType3"));
        towerTypes.Add(GameObject.Find("TowerType4"));
        for (int i = 0; i < towerTypes.Count; i++)
        {
            towerTypes[i].SetActive(false);
        }
    }
    // Use this for initialization
    void Start () {
        Utils.Log("TowerFactory:Start");

    }
    public void SpawnTower(Vector2 screenPosition,int type)
    {
        BehaviorTower bt = towerTypes[type].GetComponent<BehaviorTower>();
        int cost = bt.cost;
        PlayerController player = PlayerController.GetPlayerController();
        if(player.ConstructionPoints < cost)
        {
            player.PopMessage(0);
            return;                                                                    
        }
        player.ConstructionPoints -= cost;

        Vector3 SpawnPosition = PlayerController.GetPlayerController().SpotTarget.transform.position;
        GameObject go = GameObject.Instantiate(towerTypes[type], SpawnPosition + new Vector3(0, 4, 0), Quaternion.identity);
        go.SetActive(true);
        Debug.Log("Instantiate at" + SpawnPosition);

        /*
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (battleGround.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject go = GameObject.Instantiate(towerTypes[type], hit.point + new Vector3(0, 20, 0), Quaternion.identity);
            go.SetActive(true);
            Debug.Log("Instantiate at" + hit.point);

        }
        */
    }

    // Update is called once per frame
    void Update () {
		
	}
}
