using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour {

    public float scaler0x = 0.01f;
    public float scaler0y = 0.01f;

    public float scaler1x = 0.08f;
    public float scaler1y = 0.14f;

    // Use this for initialization
    void Start () {
 	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += new Vector3(
            Mathf.Cos(Time.fixedTime)*scaler0x + Mathf.Cos(Time.fixedTime) * scaler1x,
            0,
            Mathf.Sin(Time.fixedTime) * scaler1y + Mathf.Sin(Time.fixedTime) * scaler1y);

    }
}
