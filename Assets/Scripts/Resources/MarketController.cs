using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketController : MonoBehaviour
{
    private List<Resource> resources;
    
    public void AddResource(string name, int value, float probability, float scarcity)
    {
        Resource newResource = new Resource(name, value, probability, scarcity);
        resources.Add(newResource);
    }
    public int GetValue(string name)
    {
        Resource current;
        for (int i=0; i<resources.Count; i++)
        {
            current = resources[i];
            if (current.Name() == name)
            {
                return current.GetValue();
            }
        }
        Debug.Log("Resource Not Found!");
        return -1;
    }
}
