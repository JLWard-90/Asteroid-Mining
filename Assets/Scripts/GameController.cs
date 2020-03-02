using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    CameraManager cameraManager;
    public static GameController instance;
    void Awake()
    {
        //check if instance exists
        if (instance == null)
        {
            //assign it to the current object:
            instance = this;
        }
        //make sure instance is the current object
        else if (instance != this)
        {
            //destroy the current game object
            Destroy(gameObject);
        }
        //don't destroy on changing scene
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        cameraManager = this.gameObject.GetComponent<CameraManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("pressed N");
            if(cameraManager == null)
            {
                cameraManager = this.gameObject.GetComponent<CameraManager>();
            }
            if (cameraManager != null)
            {
                Debug.Log("Next camera");
                cameraManager.OnNextCamera();
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject.Find("NavigationManager").GetComponent<NavManager>().GoToStrategicOverlay();
        }
    }
    void LoadFromSave()
    {

    }

    void SaveToFile()
    {

    }
}
