using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public int numberOfAsteroids;
    public List<int> AsteroidSeeds;
    public List<Asteroid> asteroids;
    public Vector2 xdim = new Vector2(-20f,20f);
    public Vector2 ydim = new Vector2(-20f, 20f);
    [SerializeField]
    float astRepZpos = -164.6159f;
    [SerializeField]
    GameObject asteroidRepPrefab;
    [SerializeField]
    float shiftLength = 100; //An arbitrary length to shift the strategic overlay components away from the camera when not in use
    private void Start()
    {
        asteroids = new List<Asteroid>();
        AsteroidSeeds = new List<int>();
        for(int i=0;i<numberOfAsteroids;i++)
        {//Later add in a check here to make sure that the asteroid seeds are never repeated
            Vector2 astPosition = new Vector2(Random.Range(xdim.x,xdim.y), Random.Range(ydim.x,ydim.y));
            AddNewAsteroid(astPosition.x, astPosition.y);
            InitAsteroidRep(i);
        }
    }

    void AddNewAsteroid(float posX, float posY)
    {
        bool foundNewSeed = false; //Use this bool to check that the seed has not been used before
        while (!foundNewSeed)
        {
            int newSeed = Random.Range(0, 1000000);
            if (AsteroidSeeds.Contains(newSeed))
            {
                foundNewSeed = false;
            }
            else
            {
                AsteroidSeeds.Add(newSeed);
                Vector2 asteroidPosition = new Vector2(posX, posY);
                Asteroid newasteroid = new Asteroid(newSeed, asteroidPosition);
                asteroids.Add(newasteroid);
                foundNewSeed = true;
            }
        }
    }

    void InitAsteroidRep(int index)
    {
        Asteroid current = asteroids[index];
        Debug.Log(current);
        Vector2 position = current.position;
        GameObject newAstRep = GameObject.Instantiate(asteroidRepPrefab);
        newAstRep.transform.position = new Vector3(position.x, position.y, astRepZpos);
        newAstRep.transform.SetParent(this.gameObject.transform);
        newAstRep.gameObject.tag = "astRep";
    }

    public void InitAllAsteroidReps()
    {
        for(int i=0; i<asteroids.Count;i++)
        {
            InitAsteroidRep(i);
        }
    }

    public void shiftAway()
    {
        GameObject[] astreps = GameObject.FindGameObjectsWithTag("astRep");
        foreach(GameObject astRep in astreps)
        {
            astRep.transform.position = new Vector3(astRep.transform.position.x, astRep.transform.position.y + shiftLength, astRep.transform.position.z);
        }
    }

    public void shiftBack()
    {
        GameObject[] astreps = GameObject.FindGameObjectsWithTag("astRep");
        foreach (GameObject astRep in astreps)
        {
            astRep.transform.position = new Vector3(astRep.transform.position.x, astRep.transform.position.y - shiftLength, astRep.transform.position.z);
        }
    }
}
