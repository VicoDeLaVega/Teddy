using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour {
    int sizeButtonW = 30;
    int sizeButtonH = 30;
    public Vector2 [] MenuPlacement;

    public Rect rect0;
    public Rect rect1;
    public Rect rect2;
    public Rect rect3;
    public int HitType=0;
    public Vector2 mousePositionRec;
    public GameObject goTerrain;
    public GameObject TowerType0; 
    public void InstanciateTower0()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePositionRec);
        if (goTerrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
        {
          
            GameObject go = GameObject.Instantiate(TowerType0, hit.point+new Vector3(0,20,0),Quaternion.identity);
            Debug.Log("Instantiate at"+ hit.point);

        }
    }
    public void SetRects()
    {
        Vector2 mp = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        mousePositionRec = Input.mousePosition; 
        rect0 = new Rect(mp.x - sizeButtonW / 2 + MenuPlacement[0].x* sizeButtonW, mp.y - sizeButtonH / 2 + MenuPlacement[0].y * sizeButtonW, sizeButtonW, sizeButtonH);
      //  rect0 = new Rect(100, 100, sizeButtonW, sizeButtonH);


        rect1 = new Rect(mp.x - sizeButtonW / 2 + MenuPlacement[1].x * sizeButtonW, mp.y - sizeButtonH / 2 + MenuPlacement[1].y * sizeButtonW, sizeButtonW, sizeButtonH);
        rect2 = new Rect(mp.x - sizeButtonW / 2 + MenuPlacement[2].x * sizeButtonW, mp.y - sizeButtonH / 2 + MenuPlacement[2].y * sizeButtonW, sizeButtonW, sizeButtonH);
        rect3 = new Rect(mp.x - sizeButtonW / 2 + MenuPlacement[3].x * sizeButtonW, mp.y - sizeButtonH / 2 + MenuPlacement[3].y * sizeButtonW, sizeButtonW, sizeButtonH);

    }
    public void GetMenuRect(int idx, Rect re)
    {
        float x = MenuPlacement[idx].x;
        float y = MenuPlacement[idx].y;
        Rect r = new Rect(x - sizeButtonW / 2, y - sizeButtonH / 2, sizeButtonW, sizeButtonH);
        re = r;
        ;
    }
    public void GetMenuRect0( Rect re)
    {
        float x = MenuPlacement[0].x;
        float y = MenuPlacement[0].y;
        Rect r = new Rect(x - sizeButtonW / 2, y - sizeButtonH / 2, sizeButtonW, sizeButtonH);
        re = r;
        ;
    }
    public void SpawnButtonAroundPointerAt(float x, float y)
    {
        GUI.Button(new Rect(x - sizeButtonW / 2, y - sizeButtonH / 2, sizeButtonW, sizeButtonH), "P");

    }
    public void SpawnButtonAroundPointer(Vector2 offset)
    {
        Vector2 mp = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        SpawnButtonAroundPointerAt(mp.x+ offset.x, mp.y+ offset.y);

    }
    public void DisplayMenu()
    {
        Vector2 mp = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        SpawnButtonAroundPointerAt(mp.x , mp.y );

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
