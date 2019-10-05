using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public bool autoUpdate = true;
    [Range(2,256)] //256**2 is about the maximum number of vertices a mesh can have
    public int resolution = 10; 
    [SerializeField, HideInInspector] //Serialize so it saves in the editor but hide it from showing up in the inspector window
    MeshFilter[] meshFilters;
    TerrainFace[] terrainFaces;

    Vector3[] directions = {Vector3.up,Vector3.down,Vector3.forward,Vector3.back,Vector3.left,Vector3.right}; //All of the cardinal directions

    public ShapeSettings shapeSettings;
    public ColourSettings colourSettings;

    ShapeGenerator shapeGenerator = new ShapeGenerator();
    ColourGenerator colourGenerator = new ColourGenerator();

    [HideInInspector]
    public bool shapeSettingsFoldout;
    [HideInInspector]
    public bool colourSettingsFoldout;

    public enum FaceRenderMask {All, Top,Bottom,Left,Right,Front,Back}
    public FaceRenderMask faceRenderMask;

    public void GeneratePlanet()
    {
        Initialise();
        GenerateMesh();
        GenerateColours();
    }

    public void OnColourSettingsUpdated()
    {
        if(autoUpdate)
        {
            Initialise();
            GenerateColours();
        }
    }

    public void OnShapeSettingsUpdated()
    {
        if(autoUpdate)
        {
            Initialise();
            GenerateMesh();
        }
    }

    void Initialise()
    {
        shapeGenerator.UpdateSettings(shapeSettings);
        colourGenerator.UpdateSettings(colourSettings);
        if(meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        
        terrainFaces = new TerrainFace[6];
        for (int i=0; i<6; i++) //Iterate over 6 faces of cube
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObject = new GameObject("mesh");
                meshObject.transform.parent = transform; //Add the new meshobject to current transform

                meshObject.AddComponent<MeshRenderer>();
                meshFilters[i] = meshObject.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = colourSettings.planetMaterial;
            

            terrainFaces[i] = new TerrainFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
            bool renderFace = faceRenderMask == FaceRenderMask.All || (int) faceRenderMask - 1 == i;
            meshFilters[i].gameObject.SetActive(renderFace);
        }
    }

    void GenerateMesh()
    {
        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i].gameObject.activeSelf)
            {
                terrainFaces[i].ConstructMesh();
            }
        }

        colourGenerator.UpdateElevation(shapeGenerator.elevationMinMax);
    }

    void GenerateColours()
    {
        colourGenerator.UpdateColours();
    }
    
    
}
