using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    // Start is called before the first frame update
    //Need to get the position of the planet and ensure that the 
    private Transform currentBuilding;
    private Planet planet;
    void Start()
    {
        planet = GameObject.Find("Planet(Clone)").GetComponent<Planet>();
        Debug.Log(planet);
    }

    public void GetPlanet()
    {
        if(planet == null)
        {
            planet = GameObject.Find("Planet(Clone)").GetComponent<Planet>();
        }
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
                //Debug.Log(hit);
                if (hit.rigidbody != null && hit.transform.tag == "ground")
                {
                    //Debug.Log(hit.point);
                    currentBuilding.position = hit.point;
                    Vector3 lookVector = hit.point - hit.transform.position;
                    currentBuilding.up = lookVector;
                    if (Input.GetMouseButtonDown(0))
                    {
                        if(CheckOnGround(hit.point, planet))
                        {
                            currentBuilding = placeBuilding(currentBuilding, hit.transform);
                        }
                        else
                        {
                            Debug.Log("Cannot build here!");
                        }
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        currentBuilding = cancelBuilding(currentBuilding);
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
        GameObject.Destroy(currentBuilding.gameObject);
        currentBuilding = null;
        return currentBuilding;
    }

    bool CheckOnGround(Vector3 hitPos, Planet theplanet)
    {
        bool grounded = false;
        float distanceToCentre = 1.0f;
        distanceToCentre = Vector3.Distance(hitPos, theplanet.transform.position);
        float padding = 0.01f;
        if(distanceToCentre < theplanet.shapeSettings.planetRadius - padding || distanceToCentre > theplanet.shapeSettings.planetRadius + padding)
        {
            grounded = false;
        }
        else
        {
            grounded = true;
        }
        return grounded;
    }
}
