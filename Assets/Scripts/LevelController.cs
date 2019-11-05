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
    [SerializeField]
    GameObject playerPrefab;
    GameObject player;
    // Start is called before the first frame update
    public int seed = 1234;
    private void Awake()
    {
        planet = Instantiate(planetPrefab);
        planet.transform.position = new Vector3(0, 0, 0);
        Random.InitState(seed);
        /* List of settings to be randomised:
         * noise layer 1 centre: Vector3
         * noise layer 2 centre: Vector3
         * noise layer 3 centre: Vector3
         */
        ShapeSettings.NoiseLayer[] noiseLayers = planet.GetComponent<Planet>().shapeSettings.noiseLayers;
        foreach (ShapeSettings.NoiseLayer noiseLayer in noiseLayers)
        {
            noiseLayer.noiseSettings.simpleNoiseSettings.centre = new Vector3(Random.Range(-100f,100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            noiseLayer.noiseSettings.rigidNoiseSettings.centre = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        }
    }
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        mainCamera.focusPlanet = planet;
        planet.GetComponent<Planet>().GeneratePlanet();
        GameObject.Find("GameController").GetComponentInChildren<BuildingPlacement>().GetPlanet();
    }

    public void regeneratePlanet()
    {
        Random.InitState(seed);
        ShapeSettings.NoiseLayer[] noiseLayers = planet.GetComponent<Planet>().shapeSettings.noiseLayers;
        foreach (ShapeSettings.NoiseLayer noiseLayer in noiseLayers)
        {
            noiseLayer.noiseSettings.simpleNoiseSettings.centre = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            noiseLayer.noiseSettings.rigidNoiseSettings.centre = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        }
        planet.GetComponent<Planet>().GeneratePlanet();
    }

  
}
