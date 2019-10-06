using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public bool testLevel = true;
    CameraController mainCamera;
    GameObject planet;
    [SerializeField]
    GameObject planetPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        planet = Instantiate(planetPrefab);
        planet.transform.position = new Vector3(0, 0, 0);
    }
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        mainCamera.focusPlanet = planet;
        planet.GetComponent<Planet>().GeneratePlanet();
    }

    
}
