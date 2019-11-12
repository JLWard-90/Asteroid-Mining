using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public int numberOfAsteroids;
    public int[] AsteroidSeeds;
    public List<Asteroid> asteroids;

    private void Start()
    {
        asteroids = new List<Asteroid>();
        AsteroidSeeds = new int[numberOfAsteroids];
        for(int i=0;i<numberOfAsteroids;i++)
        {//Later add in a check here to make sure that the asteroid seeds are never repeated
            AsteroidSeeds[i] = Random.Range(0, 1000000);
            asteroids.Add(new Asteroid(AsteroidSeeds[i]));
        }
    }

    void AddNewAsteroid()
    {

    }
}
