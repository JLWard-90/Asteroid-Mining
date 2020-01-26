using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    //Basic values for all resources
    private int value; //Everything has a value per tonne
    private float probabilityOnAsteroid; //The likelihood that it will be on an asteroid at all
    private float scarcity; //The average amount per asteroid if it is present

    public int GetValue()
    {
        return value;
    }
    public void SetValue(int newValue)
    {
        value = newValue;
    }
    public float Probability()
    {
        return probabilityOnAsteroid;
    }
    public float Scarcity()
    {
        return scarcity;
    }
}
