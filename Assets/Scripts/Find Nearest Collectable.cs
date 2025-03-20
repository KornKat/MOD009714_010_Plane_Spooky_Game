using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestCollectable : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject[] allObjectsWithTag;
    public LineRenderer myLineRenderer;
    public GameObject Plane;
    public GameObject Collectable;
    // Start is called before the first frame update
    void Start()
    {
        allObjectsWithTag = GameObject.FindGameObjectsWithTag("Ring");
        myLineRenderer.positionCount = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject nearestObject = allObjectsWithTag[0];
        float distanceToNearest = Vector3.Distance(targetObject.transform.position, nearestObject.transform.position);
        for (int i = 1; i < allObjectsWithTag.Length; i++) 
        {
            float distanceToCurrent = Vector3.Distance(targetObject.transform.position, allObjectsWithTag[i].transform.position);
            if (distanceToCurrent < distanceToNearest) 
            { 
                nearestObject = allObjectsWithTag[i];
                distanceToNearest = distanceToCurrent;
            }
        }

        foreach (GameObject g in allObjectsWithTag) 
        {
            myLineRenderer.SetPosition(0, Plane.transform.position);
            myLineRenderer.SetPosition(0, nearestObject.transform.position);
        }

        
    }
}
