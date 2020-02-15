using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    AsteroidManager asteroidManager;
    GameController gameController;
    [SerializeField]
    GameObject planetPrefab;
    private void Awake()
    {
        asteroidManager = this.gameObject.GetComponent<AsteroidManager>();
        gameController = this.gameObject.GetComponent<GameController>();
    }
    private void GenerateAsteroid(int asteroidIndex)
    {
        bool asteroidPreviouslyGenerated = asteroidManager.asteroids[asteroidIndex].prevgenerated;
        if (asteroidPreviouslyGenerated)
        {
            return;
        }
        int seed = asteroidManager.asteroids[asteroidIndex].seedValue;
        GameObject newPlanet = Instantiate(planetPrefab);
        newPlanet.transform.position = new Vector3(asteroidManager.asteroids[asteroidIndex].position.x, asteroidManager.asteroids[asteroidIndex].position.y, 0);
        Random.InitState(seed);
        ShapeSettings.NoiseLayer[] noiseLayers = newPlanet.GetComponent<Planet>().shapeSettings.noiseLayers;
        foreach (ShapeSettings.NoiseLayer noiseLayer in noiseLayers)
        {
            noiseLayer.noiseSettings.simpleNoiseSettings.centre = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            noiseLayer.noiseSettings.rigidNoiseSettings.centre = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        }
        newPlanet.transform.SetParent(gameController.transform);
        asteroidManager.planets[asteroidIndex] = newPlanet;
    }

    public void GenerateAsteroids()
    {
        int nAsteroids = asteroidManager.numberOfAsteroids;
        for (int i = 0; i < nAsteroids; i++)
        {
            GenerateAsteroid(i);
        }
    }
}
