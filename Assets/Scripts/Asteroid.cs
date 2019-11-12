using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int seedValue;
    public Vector2 position;
    public Asteroid(int initSeed, Vector2 position)
    {
        this.seedValue = initSeed;
        this.position = position;
    }
}
