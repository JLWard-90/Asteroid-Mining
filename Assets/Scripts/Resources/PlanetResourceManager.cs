using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetResourceManager : MonoBehaviour
{
    List<Resource> planetResources;
    MarketController market;
    // Start is called before the first frame update
    void Start()
    {
        if (market == null)
        {
            market = GameObject.Find("GameController").GetComponent<MarketController>();
        }
    }

    void InitResources()
    {
        //planetResources.Add();
        List<Resource> marketResources = market.GetResourcesList();
        foreach (Resource item in marketResources)
        {
            //For each resource need to map a quantity to the asteroid.
        }
    }
}
