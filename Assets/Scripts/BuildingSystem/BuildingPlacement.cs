﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    // Start is called before the first frame update
    //Need to get the position of the planet and ensure that the 
    private Transform currentBuilding;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBuilding != null)
        {
            //Vector3 mousePosition = Input.mousePosition;
            //mousePosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.y);
            //Vector3 p = camera.ScreenToWorldPoint(mousePosition);
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit);
                if (hit.rigidbody != null && hit.transform.tag == "ground")
                {
                    Debug.Log(hit.point);
                    currentBuilding.position = hit.point;
                    Vector3 lookVector = hit.point - hit.transform.position;
                    currentBuilding.up = lookVector;
                    if (Input.GetMouseButtonDown(0))
                    {
                        currentBuilding = placeBuilding(currentBuilding, hit.transform);
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        cancelBuilding(currentBuilding);
                    }
                }
            }
            
               
        }
    }

    public void SetItem(GameObject b)
    {
        currentBuilding = Instantiate(b).transform;
    }

    Transform placeBuilding(Transform currentBuilding, Transform hitTransform)
    {
        currentBuilding.SetParent(hitTransform);
        currentBuilding = null;
        return currentBuilding;
    }

    Transform cancelBuilding(Transform currentBuilding)
    {
        currentBuilding = null;
        return currentBuilding;
    }
}
