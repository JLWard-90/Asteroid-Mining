using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float cameraSpeed = 1;
    [SerializeField]
    float zoomSpeed = 0.2f;
    [SerializeField]
    Vector2 zoomMinMax;

    [SerializeField]
    public GameObject focusPlanet;

    public float zoomDist = 3;
    private void Start()
    {
        if(focusPlanet == null)
        {
            focusPlanet = GameObject.Find("Planet(Clone)");
        }
    }
    private void Update()
    {
        RotateHandler(focusPlanet);
        ZoomHandler();
        PointToFocus(focusPlanet);
    }

    private void RotateHandler(GameObject focus) //Handler to pan the camera around the asteroid
    {
        float hAxis = Input.GetAxis("Horizontal");
        if (hAxis != 0)
        {
            Vector3 moveRot = transform.up;
            focus.transform.Rotate(moveRot * cameraSpeed * Time.deltaTime * hAxis);
        }
        float vAxis = Input.GetAxis("Vertical");
        if(vAxis != 0)
        {
            Vector3 moveRot = transform.right * -1;
            focus.transform.Rotate(moveRot * cameraSpeed * Time.deltaTime * vAxis,Space.World);
        }
    }
    private void ZoomHandler()
    {
        float zoomAxis1 = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(zoomAxis1);
        float zoomAxis2 = Input.GetAxis("HomeEnd");
        if (zoomAxis1 != 0)
        {
            float newZoomDist = zoomDist + zoomAxis1 * zoomSpeed * Time.deltaTime * -10;
            if (newZoomDist < zoomMinMax[1] && newZoomDist > zoomMinMax[0])
            {
                zoomDist = newZoomDist;
            }
            else
            {
                Debug.Log("zoom out of bounds");
            }
        }
        if (zoomAxis2 != 0)
        {
            float newZoomDist = zoomDist + zoomAxis2 * zoomSpeed * Time.deltaTime * -1;
            if (newZoomDist < zoomMinMax[1] && newZoomDist > zoomMinMax[0])
            {
                zoomDist = newZoomDist;
            }
            else
            {
                Debug.Log("zoom out of bounds");
            }
        }
    }

    private void PointToFocus(GameObject focus)
    {
        Vector3 focusPosition = focus.transform.position;
        transform.position = focusPosition - transform.forward * zoomDist;
    }

}
