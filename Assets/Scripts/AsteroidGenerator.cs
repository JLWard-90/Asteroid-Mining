﻿using System.Collections;
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
        newPlanet.transform.position = new Vector3(asteroidManager.asteroids[asteroidIndex].position.x, asteroidManager.asteroids[asteroidIndex].position.y, -50);
        Random.InitState(seed);
        ShapeSettings.NoiseLayer[] noiseLayers = newPlanet.GetComponent<Planet>().shapeSettings.noiseLayers;
        foreach (ShapeSettings.NoiseLayer noiseLayer in noiseLayers)
        {
            noiseLayer.noiseSettings.simpleNoiseSettings.centre = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            noiseLayer.noiseSettings.rigidNoiseSettings.centre = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        }
        newPlanet.transform.SetParent(gameController.transform);
        asteroidManager.planets[asteroidIndex] = newPlanet;
        newPlanet.GetComponent<Planet>().GeneratePlanet();
        asteroidManager.asteroids[asteroidIndex].prevgenerated = true;
    }

    public void RegenerateAsteroid(int asteroidIndex)
    {
        GameObject planet = asteroidManager.planets[asteroidIndex];
        int seed = asteroidManager.asteroids[asteroidIndex].seedValue;
        Random.InitState(seed);
        ShapeSettings.NoiseLayer[] noiseLayers = planet.GetComponent<Planet>().shapeSettings.noiseLayers;
        foreach (ShapeSettings.NoiseLayer noiseLayer in noiseLayers)
        {
            noiseLayer.noiseSettings.simpleNoiseSettings.centre = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            noiseLayer.noiseSettings.rigidNoiseSettings.centre = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        }
        planet.GetComponent<Planet>().GeneratePlanet();
    }


    public void GenerateAsteroids()
    {
        int nAsteroids = asteroidManager.numberOfAsteroids;
        for (int i = 0; i < nAsteroids; i++)
        {
            GenerateAsteroid(i);
            Debug.Log(string.Format("Asteroid {0} generated", i));
        }
    }
}
