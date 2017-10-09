using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuPage2 : MonoBehaviour {

    public GameObject Page2Plane;
    public Camera Page2Camera;
    public List<GameObject> LevelObjects;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Vector2 mousePosition = Input.mousePosition;
            Ray ray = Page2Camera.ScreenPointToRay(mousePosition);
            for (int i = 0; i < LevelObjects.Count; i++)
            {
                GameObject go = LevelObjects[i];
                if(go.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
                {
                    Debug.Log(hit.collider.gameObject.name);
                }
            }
//            if (Page2Plane.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {

           //     Debug.Log(hit.collider.gameObject.name);
           //     SpotTarget.transform.position = Utils.Snap(hit.point, 6);
             //   SpotTarget.SetActive(true);
                //   /*GameObject go = */GameObject.Instantiate(TowerType0, hit.point+new Vector3(0,20,0),Quaternion.identity);
                //   Debug.Log("Instantiate at" + hit.point);
            }

        }
        
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(2);
    }
}
