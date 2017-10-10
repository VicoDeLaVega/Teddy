using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.MeshGeneration.Factories;

using Mapbox.Directions;
using Mapbox.Unity.Map;

using Mapbox.Platform;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using System.IO;

public class TDPath : MonoBehaviour {
    [System.Serializable]
    public class SerializedPoints
    {
        public List<Vector3> pathPoints;
    }
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
    public SerializedPoints serializedPoints;
    public DirectionsFactory directionsFactory;
    public bool saved = false;
    public bool load = true;
    public bool loaded = false;
    public int GetCount()
    {
        if (loaded == true)
            return serializedPoints.pathPoints.Count;
        else
        return directionsFactory.points.Count;
    }
    public Vector3 GetPoint(int idx)
    {
        if (loaded == true)
            return serializedPoints.pathPoints[idx];
        else
            return directionsFactory.points[idx];
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (load)
        {
            //Read the text from directly from the test.txt file
            StreamReader reader = new StreamReader("path.json");
            string json = reader.ReadToEnd();
            Debug.Log(reader.ReadToEnd());
            serializedPoints = JsonUtility.FromJson<SerializedPoints>(json);
            reader.Close();
            if(serializedPoints.pathPoints.Count>0)
            {
                loaded = true;
            }
            load = false;
        }
        if (loaded==false && saved == false && GetCount() > 0)
        {
            for (int i = 0; i < GetCount(); i++)
            {
                serializedPoints.pathPoints.Add(GetPoint(i));
            }
            string s = JsonUtility.ToJson(serializedPoints);
            //Write some text to the test.txt file
            System.IO.StreamWriter writer = new StreamWriter("path.json", true);
            writer.WriteLine(s);
            writer.Close();
            saved = true;
        }
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
