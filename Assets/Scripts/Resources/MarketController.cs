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
        Debug.Log("MarketController::GetValue Error: Resource not found!");
        return -1;
    }
    public void SetValue(string name, int newValue)
    {
        Resource current;
        for (int i=0; i< resources.Count; i++)
        {
            current = resources[i];
            if(current.Name() == name)
            {
                current.SetValue(newValue);
            }
        }
        Debug.LogError("MarketController::SetValue Error: Resource not found!");
    }
    public float GetProbability(string name)
    {
        Resource current;
        for (int i=0;i<resources.Count; i++)
        {
            current = resources[i];
            if(current.Name() == name)
            {
                return current.Probability();
            }
        }
        Debug.Log("MarketController::GetProbability Error: Resource not found!");
        return 0;
    }
    public float GetScarcity(string name)
    {
        Resource current;
        for(int i=0; i < resources.Count; i++)
        {
            current = resources[i];
            if(current.Name() == name)
            {
                return current.Scarcity();
            }
        }
        Debug.LogError("MarketController::GetScarcity Error: Resource not found!");
        return 0;
    }

    public List<Resource> GetResourcesList()
    {
        return resources;
    }
}
