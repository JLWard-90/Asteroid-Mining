using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings settings;
    NoiseFilter[] noiseFilters;
    public ShapeGenerator(ShapeSettings shapeSettings)
    {
        this.settings = shapeSettings;
        if(settings.noiseLayers != null)
        {
            noiseFilters = new NoiseFilter[settings.noiseLayers.Length];//NoiseFilter(settings.noiseSettings);
            for (int i=0; i < noiseFilters.Length; i++)
            {
                noiseFilters[i] = new NoiseFilter(settings.noiseLayers[i].noiseSettings);
            }
        }
        else
        {
            Debug.Log("Error in shapeGenerator: no noiseLayers found!");
        }
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float elevation = 0; //noiseFilter.evaluate(pointOnUnitSphere);
        float firstLayerVal = 0;
        if (noiseFilters.Length > 0)
        {
            firstLayerVal = noiseFilters[0].evaluate(pointOnUnitSphere);
            if (settings.noiseLayers[0].enabled)
            {
                elevation = firstLayerVal;
            }
        }

        for (int i = 1; i < noiseFilters.Length; i++)
        {
            if (settings.noiseLayers[i].enabled)
            {
                float mask = (settings.noiseLayers[i].useFirstLayerAsMask)? firstLayerVal : 1;
                elevation += noiseFilters[i].evaluate(pointOnUnitSphere) * mask;
            }
        }
        return pointOnUnitSphere * settings.planetRadius * (1+elevation);
    }
}
