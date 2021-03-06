﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings settings;
    iNoiseFilter[] simpleNoiseFilters;
    public MinMax elevationMinMax;

    public void UpdateSettings(ShapeSettings shapeSettings)
    {
        this.settings = shapeSettings;
        if(settings.noiseLayers != null)
        {
            simpleNoiseFilters = new iNoiseFilter[settings.noiseLayers.Length];//SimpleNoiseFilter(settings.noiseSettings);
            for (int i=0; i < simpleNoiseFilters.Length; i++)
            {
                simpleNoiseFilters[i] = NoiseFilterFactory.CreateNoiseFilter(settings.noiseLayers[i].noiseSettings);
            }
        }
        else
        {
            Debug.Log("Error in shapeGenerator: no noiseLayers found!");
        }
        elevationMinMax = new MinMax();
    }



    public float CalculateUnscaledElevation(Vector3 pointOnUnitSphere)
    {
        float elevation = 0; //simpleNoiseFilter.evaluate(pointOnUnitSphere);
        float firstLayerVal = 0;
        if (simpleNoiseFilters.Length > 0)
        {
            firstLayerVal = simpleNoiseFilters[0].evaluate(pointOnUnitSphere);
            if (settings.noiseLayers[0].enabled)
            {
                elevation = firstLayerVal;
            }
        }

        for (int i = 1; i < simpleNoiseFilters.Length; i++)
        {
            if (settings.noiseLayers[i].enabled)
            {
                float mask = (settings.noiseLayers[i].useFirstLayerAsMask)? firstLayerVal : 1;
                elevation += simpleNoiseFilters[i].evaluate(pointOnUnitSphere) * mask;
            }
        }
        elevationMinMax.AddValue(elevation);
        return elevation;
    }

    public float GetScaledElevation(float unscaledElevation)
    {
        float elevation = Mathf.Max(0, unscaledElevation);
        elevation = settings.planetRadius * (1 + elevation);
        return elevation;
    }
}
