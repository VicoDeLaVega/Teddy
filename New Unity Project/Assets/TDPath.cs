using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.MeshGeneration.Factories;

using Mapbox.Directions;
using Mapbox.Unity.Map;

using Mapbox.Platform;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
public class TDPath : MonoBehaviour {

    //public DirectionsFactory directionsFactory;
    //public List<Vector3> points;

    //public Vector3 start;
    //public Vector3 end;
    //public Vector3 direction;
    //public float distance;
    //public int currentStart = 0;
    //public int currentEnd = 1;
    //bool firstFrame = true;

    //Vector3 currentPosition;
    //Vector3 currentLookAtPoint;
    // Use this for initialization
    public DirectionsFactory directionsFactory;
    public int GetCount()
    {
        return directionsFactory.points.Count;
    }
    public Vector3 GetPoint(int idx)
    {
        return directionsFactory.points[idx];
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //start = directionsFactory.points[currentStart];
        //end = directionsFactory.points[currentEnd];
        //direction = (end - start).normalized;
        //distance = (end - currentPosition).magnitude;
        //transform.LookAt(end);
        //if (distance > 10f)
        //{
        //    transform.position += direction * Time.deltaTime * speed;
        //}
        //else
        //{
        //    if (currentEnd < directionsFactory.points.Count - 2)
        //    {
        //        currentEnd++;
        //        currentStart++;
        //    }
        //    else
        //    {
        //        currentEnd = 1;
        //        currentStart = 0;
        //        transform.position = directionsFactory.points[currentStart];

        //    }

        //}

    }
}
