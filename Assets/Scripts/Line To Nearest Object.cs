using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineToNearestObject : MonoBehaviour
{
    public string targetTag = "Ring";
    private GameObject nearestTarget;
    private LineRenderer lineRenderer;
    public Material lineMaterial;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.4f;
        lineRenderer.endWidth = 0.4f;
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        nearestTarget = FindNearestTarget();
        if (nearestTarget != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, nearestTarget.transform.position);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
    GameObject FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject nearestTarget = null;
        float minimumDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(GameObject target in targets) 
        {
            float distance = Vector3.Distance(currentPosition, target.transform.position);
            if(distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestTarget = target;
            }
        }
        return nearestTarget;

    }
}
