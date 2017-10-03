using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.MeshGeneration.Factories;

using Mapbox.Directions;
using Mapbox.Unity.Map;

using Mapbox.Platform;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;

public class FollowPath : MonoBehaviour {
  //  public DirectionsFactory directionsFactory;
  //  public List<Vector3> points;
    public TDPath path;
    public Vector3 start;
    public Vector3 end;
    public Vector3 direction;
    public float distance;
    public int currentStart = 0;
    public int currentEnd = 1;
    bool firstFrame = true;
    public float speed = 10;
    public float startTime = 0;
    public float internalTime = 0;
    // Use this for initialization
    void Start()
    {
        internalTime = Time.fixedTime;
     //   Debug.Log("internalTime"+ internalTime);

    }

    // Update is called once per frame
    void Update()
    {
        int countWP = path.GetCount();
        if (countWP < 1)
            return;
        if ((internalTime + startTime) > Time.fixedTime)
            return;
        if (firstFrame)
        {
            transform.position = path.GetPoint(currentStart);
            firstFrame = false;
          //  Debug.Log("firstFrame" + Time.fixedTime);
        }
        {

            start = path.GetPoint(currentStart);
            end = path.GetPoint(currentEnd);
            direction = (end - start).normalized;
            distance = (end - transform.position).magnitude;
          
            if (distance > 10f)
            {
                transform.position += direction * Time.deltaTime * speed;
                transform.LookAt(end);
            }
            else
            {
                if (currentEnd < path.GetCount() - 2)
                {
                    currentEnd++;
                    currentStart++;
                }
                else
                {
                   // currentEnd = 1;
                   // currentStart = 0;
                  //  transform.position = path.GetPoint(currentStart);
                    Destroy(gameObject,1);
                    PlayerController pc = PlayerController.GetPlayerController();
                    pc.BaseLifePoints -= 100;
                }

            }

        }

    }
}
