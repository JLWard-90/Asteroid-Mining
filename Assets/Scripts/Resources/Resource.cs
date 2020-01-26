using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    //Basic values for all resources
    private string resourceName; //name of resource
    private int value; //Everything has a value per tonne
    private float probabilityOnAsteroid; //The likelihood that it will be on an asteroid at all
    private float scarcity; //The average amount per asteroid if it is present

    public Resource(string name, int value, float prob, float scarcity)
    {
        this.resourceName = name;
        this.value = value;
        this.probabilityOnAsteroid = prob;
        this.scarcity = scarcity;
    }

    public int GetValue()
    {
        return value;
    }
    public string Name()
    {
        return resourceName;
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
