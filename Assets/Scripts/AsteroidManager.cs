using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public int numberOfAsteroids;
    public int[] AsteroidSeeds;

    private void Start()
    {
        AsteroidSeeds = new int[numberOfAsteroids];
        for(int i=0;i<numberOfAsteroids;i++)
        {
            AsteroidSeeds[i] = Random.Range(0, 1000000);
        }
    }
}
