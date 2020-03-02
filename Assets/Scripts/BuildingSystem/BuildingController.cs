using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    bool buildmodeOn = false;
    private void FixedUpdate()
    {
        if(buildmodeOn)
        {
            Debug.Log("Building mode on");
        }
    }

    Vector3 getPointInPlanetSpace()
    {
        //Returns a position relative to the planet transform to apply to the building object
        Vector3 position = new Vector3(0, 0, 0);
        return position;
    }

    Vector3 getRotationLocalUp()
    {
        //Returns a rotation to apply to the building object to ensure it stays pointing upwards
        Vector3 rotation = new Vector3(0,0,0);
        return rotation;
    }
}
