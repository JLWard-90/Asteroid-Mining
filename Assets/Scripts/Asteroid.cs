using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Asteroid
{
    public int seedValue;
    public Vector2 position;
    public bool prevgenerated = false; //A boolean to contain whether or not the asteroid has already been generated. When it has, we can just store the Planet object in RAM and load it to screen instead of regenerating the planet every time
    public Asteroid(int initSeed, Vector2 position)
    {
        this.seedValue = initSeed;
        this.position = position;
    }
}
