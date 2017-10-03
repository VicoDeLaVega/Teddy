using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {
    
    public static  Vector3 Snap(Vector3 v,float unit)
    {
        return new Vector3(
               Mathf.Floor((v.x+unit/2) / unit) * unit,
               Mathf.Floor((v.y) / unit) * unit,
               Mathf.Floor((v.z + unit / 2) / unit) * unit);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
