using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<Camera> cameras;
    Camera currentCamera;
    int cameraNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        cameras = new List<Camera>();
        cameras.Add(GameObject.Find("Main Camera").GetComponent<Camera>());
        cameraNumber = 0;
        currentCamera = cameras[cameraNumber];
    }

    public void OnNextCamera()
    {
        currentCamera.enabled = false;
        if (cameras.Count == 1)
        {
            currentCamera.enabled = true;
            return;
        }
        if (cameraNumber < cameras.Count-1)
        {
            cameraNumber++;
            currentCamera = cameras[cameraNumber];
            currentCamera.enabled = true;
        }
        else
        {
            cameraNumber = 0;
            currentCamera = cameras[cameraNumber];
            currentCamera.enabled = true;
        }
    }

    public void AddCamera(Camera camera)
    {
        cameras.Add(camera);
    }
}
