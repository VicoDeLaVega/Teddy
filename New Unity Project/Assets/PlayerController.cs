using Mapbox.Unity.MeshGeneration.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public int BaseLifePoints = 1000;
    public int ConstructionPoints = 1000;
    public Text TextLifePoints;
    public Text TextConstructionPoints;
    public Text TextNeedMoreCoins;
    public Text TextSelectBaseLocation;
    public GameObject ButtonConfirmBasePlacement;

    public GameObject battleGround;
    public GameObject SpotTarget;
    public GameObject BaseSpotTarget;
    public GameObject BaseObject;

    public LevelController Level0;

    bool BaseLocationConfirmed = false ;
    public DirectionsFactory directionFactory;
    public GameObject endPath;

    public Material OriginalBuildingMaterial;
    public Material OverlapBuildingMaterial;

    public static PlayerController instance;
    public static PlayerController GetPlayerController()
    {
        return instance;
    }
    void Awake()
    {
        Utils.Log("Pc:Awake");
        instance = this;
        SpotTarget = GameObject.Find("SpotTarget");
        SpotTarget.SetActive(false);
        BaseSpotTarget = GameObject.Find("BaseSpotTarget");
        BaseSpotTarget.SetActive(false);
        TextNeedMoreCoins.enabled = false;
        TextSelectBaseLocation.enabled = false;
        BaseObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
        Utils.Log("Pc:Start");
    }
	
	// Update is called once per frame
	void Update ()
    {

        TextLifePoints.text = "Life:" + BaseLifePoints;
        TextConstructionPoints.text = "Coins:" + ConstructionPoints;
    }

    public void PopMessage(int typeMessage)
    {
        if(typeMessage==0)
        {
            PopMessageText pmt = TextNeedMoreCoins.GetComponent<PopMessageText>();
            if (pmt)
                pmt.Pop(1);
        }
        //if(typeMessage==1)
        //{
        //    PopMessageText pmt = TextSelectBaseLocation.GetComponent<PopMessageText>();
        //    if (pmt)
        //        pmt.Pop(1);

        //}
    }

    public void PlaceSpotTarget(Vector3 mousePosition)
    {
        SpotTarget.SetActive(false);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            MeshRenderer mr = hits[i].collider.gameObject.GetComponent<MeshRenderer>();
            if (mr)
            {
                Debug.Log("hit:" + hits[i].collider.gameObject.name);
             //   mr.material = OverlapBuildingMaterial;
                SpotTarget.transform.position = Utils.Snap(hits[i].point, 6);
                SpotTarget.SetActive(true);

            }
        }
     /*   if (battleGround.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
        {
            SpotTarget.transform.position = Utils.Snap(hit.point, 6);
            SpotTarget.SetActive(true);

            MeshRenderer mr = hit.collider.gameObject.GetComponent<MeshRenderer>();
            if (mr)
            {
                Debug.Log("hit:" + hit.collider.gameObject.name);
                mr.material = OverlapBuildingMaterial;
            }
        }*/
    }
    public bool IsBaseReady()
    {
        return BaseLocationConfirmed;
    }
    public void StartLevel()
    {
        BaseObject.transform.position = BaseSpotTarget.transform.position;
        BaseObject.SetActive(true);

        endPath.transform.position = BaseObject.transform.position;
        directionFactory.gameObject.SetActive(true);
        directionFactory.Query();
        Level0.BasePosition = BaseObject.transform.position;
        Level0.GenerateRoutes();
        Level0.StartLevel();
        ButtonConfirmBasePlacement.SetActive(false);
        TextSelectBaseLocation.enabled = false;
    }

    public void ConfirmBaseLocation()
    {
        BaseLocationConfirmed = true;
    }

    public void PlaceBaseLocationTarget()
    {
        Utils.TDDebug("pb:PlaceBaseLocationTarget");

        ButtonConfirmBasePlacement.SetActive(true);
        BaseSpotTarget.SetActive(false);
        TextSelectBaseLocation.enabled = true;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));
        if (battleGround.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
        {
            BaseSpotTarget.transform.position = Utils.Snap(hit.point, 6);
            BaseSpotTarget.SetActive(true);

            MeshRenderer mr = hit.collider.gameObject.GetComponent<MeshRenderer>();
            if (mr)
            {
                mr.material = OverlapBuildingMaterial;
            }
         }
    }

    public void SignalEnemyDestroyed(int type)
    {
        ConstructionPoints += 10;
    }
}
