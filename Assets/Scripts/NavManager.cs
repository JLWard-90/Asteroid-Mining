using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavManager : MonoBehaviour
{
    public int selectedAsteroidIndex;
    public static NavManager instance;
    [SerializeField]
    AsteroidManager asteroidManager;
    [SerializeField]
    GameObject asteroidCameraObject;
    [SerializeField]
    GameObject StrategicViewCameraObject;
    float timer = 0;
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
        asteroidManager = GameObject.Find("GameController").GetComponent<AsteroidManager>();
        Debug.Log(asteroidManager);
    }


    public void LoadAsteroidView()
    {
        if(asteroidManager != null)
        {
            asteroidManager.astRepList[selectedAsteroidIndex].GetComponent<astRepControl>().OnDeselect();
        }
        else
        {
            asteroidManager = GameObject.Find("GameController").GetComponent<AsteroidManager>();
            asteroidManager.astRepList[selectedAsteroidIndex].GetComponent<astRepControl>().OnDeselect();
        }
        //SceneManager.LoadScene("AsteroidScene");
        if (StrategicViewCameraObject == null)
        {
            StrategicViewCameraObject = GameObject.Find("Main Camera");
        }
        if (asteroidCameraObject == null)
        {
            asteroidCameraObject = GameObject.Find("AsteroidCamera");
        }
        StrategicViewCameraObject.GetComponent<Camera>().enabled = false;
        StrategicViewCameraObject.GetComponent<AudioListener>().enabled = false;
        asteroidCameraObject.GetComponent<Camera>().enabled = true;
        asteroidCameraObject.GetComponent<AudioListener>().enabled = true;
        asteroidCameraObject.GetComponent<CameraController>().enabled = true;
        asteroidCameraObject.GetComponent<CameraController>().SetFocusPlanet(asteroidManager.planets[selectedAsteroidIndex]);
        Debug.Log("Loading asteroid view");
        Debug.Log(selectedAsteroidIndex);
    }
    public void GoToStrategicOverlay()
    {
        //GameObject.Find("Planet(Clone)").SetActive(false);
        //SceneManager.LoadScene("StrategicScreen");
        //asteroidManager = GameObject.Find("GameController").GetComponent<AsteroidManager>();
        //asteroidManager.ShiftBack();
        //asteroidManager.InitAllAsteroidReps();
        asteroidCameraObject.GetComponent<CameraController>().enabled = false;
        asteroidCameraObject.GetComponent<Camera>().enabled = false;
        asteroidCameraObject.GetComponent<AudioListener>().enabled = false;
        StrategicViewCameraObject.GetComponent<Camera>().enabled = true;
        StrategicViewCameraObject.GetComponent<AudioListener>().enabled = true;
    }
    public string getSceneName()
    {
        string name = "";
        Scene scene = SceneManager.GetActiveScene();
        name = scene.name;
        return name;
    }
}
