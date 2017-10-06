using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {

    public List<GameObject> Page1Objects;
    public List<GameObject> Page2Objects;
    // Use this for initialization
    void Start () {
        SetPage1();
	}
    public void SetPage1()
    {
        for (int i = 0; i < Page1Objects.Count; i++)
        {
            Page1Objects[i].SetActive(true);
        }

        for (int i = 0; i < Page2Objects.Count; i++)
        {
            Page2Objects[i].SetActive(false);
        }
    }
    public void SetPage2()
    {
        for (int i = 0; i < Page1Objects.Count; i++)
        {
            Page1Objects[i].SetActive(false);
        }

        for (int i = 0; i < Page2Objects.Count; i++)
        {
            Page2Objects[i].SetActive(true);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
