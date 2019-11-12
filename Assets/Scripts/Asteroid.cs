using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int seedValue;
    public Vector2 position;
    public Asteroid(int initSeed)
    {
        this.seedValue = initSeed;
    }
}
