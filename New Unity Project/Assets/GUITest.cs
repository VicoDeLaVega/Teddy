using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITest : MonoBehaviour
{
    public GameObject goTerrain;

    public bool active = true;
    public int sizeButtonW = 30;
    public int sizeButtonH = 30;
    public Vector2 mousePosition;

  //  int State = 0;
    
  //  void Update()
  //  {
     

        //if (Input.GetMouseButtonUp(0))
        //{
        //    active = true;
        //    mousePosition = Input.mousePosition;
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (goTerrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
        //    {
        //        transform.position = hit.point;
        //    }
        //}
  //  }
    void SpawnButtonAroundPointerAt(float x, float y)
    {
         GUI.Button(new Rect(x - sizeButtonW / 2, y - sizeButtonH / 2, sizeButtonW, sizeButtonH), "P");

    }
    void OnGUI()
    {
      
        if (Input.GetMouseButtonUp(0))
        {
            active = true;
            mousePosition = Input.mousePosition;

        }
        if (active)
        {
         //   GUI.Box(new Rect(100,100, 20, 20), "P");

            Vector2 mp = new Vector2(mousePosition.x,Screen.height-mousePosition.y);
            SpawnButtonAroundPointerAt(mp.x, mp.y);
            //Debug.Log("puu");
        }
        // Make a background box
    //    GUI.Box(new Rect(10, 100, 200, 10), "Loader Menu");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
     //   if (GUI.Button(new Rect(20, 40, 80, 20), "Level 1"))
        {
           // Application.LoadLevel(1);
        }

        // Make the second button.
      //  if (GUI.Button(new Rect(20, 70, 80, 20), "Level 2"))
        {
           // Application.LoadLevel(2);
        }
    }
}