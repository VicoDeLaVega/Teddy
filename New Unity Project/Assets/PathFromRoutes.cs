using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.MeshGeneration.Factories;

using Mapbox.Directions;
using Mapbox.Unity.Map;

using Mapbox.Platform;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
public class PathFromRoutes : MonoBehaviour {
    public DirectionsFactory directionsFactory;
    public List<Vector3> points;
    public Transform target;
    public Vector3 start ;
    public Vector3 end ;
    public Vector3 direction;
    public float distance;
    public int currentStart = 0;
    public int currentEnd = 1;
    bool firstFrame = true;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        int countWP = directionsFactory.points.Count;
        if (countWP < 1)
            return;
        if (firstFrame)
        {
            target.position = directionsFactory.points[currentStart];
            firstFrame = false;
        }
     
        {
            
            start = directionsFactory.points[currentStart];
            end = directionsFactory.points[currentEnd];
            direction = (end - start).normalized;
            distance = (end-target.position).magnitude;
            target.LookAt(end);
            if (distance > 10f)
            {
                target.position += direction * Time.deltaTime *10;
            }
            else
            {
                if (currentEnd < directionsFactory.points.Count - 2)
                {
                    currentEnd++;
                    currentStart++;
                }
                else
                {
                    currentEnd = 1;
                    currentStart = 0;
                    target.position = directionsFactory.points[currentStart];

                }

            }

        }

    }
}
