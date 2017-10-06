using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopMessageText : MonoBehaviour {
    Text textObject;
    float timeToStop;
	// Use this for initialization
	void Start () {
        textObject = gameObject.GetComponent<Text>();
        textObject.enabled = false;

    }
	public void Pop(float duration)
    {
        timeToStop = Time.fixedTime + duration;
    }
	// Update is called once per frame
	void Update () {
        if (timeToStop < Time.fixedTime)
        {
            textObject.enabled = false;
        }
        else
        {
            textObject.enabled = true;
        }

    }
}
