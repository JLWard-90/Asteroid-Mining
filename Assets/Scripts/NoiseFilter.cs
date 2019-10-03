using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter 
{
    NoiseSettings settings;
    Noise noise = new Noise();

    public NoiseFilter(NoiseSettings settings)
    {
        this.settings = settings;
    }

    public float evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = settings.baseRoughness;
        float amplitude = 1;

        for (int i=0; i < settings.nLayers; i++)
        {
            float v = noise.Evaluate(point*frequency+settings.centre);
            noiseValue += (v+1)*.5f * amplitude;
            frequency *= settings.roughness; //roughness > 1 -> frequency of noise increases with each layer
            amplitude *= settings.persistence; //persistence < 1 -> amplitude decreases with each layer
        }
        noiseValue = Mathf.Max(0, noiseValue-settings.minValue);
        return noiseValue * settings.strength;
    }
}
