using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2,256)] //256**2 is about the maximum number of vertices a mesh can have
    public int resolution = 10; 
    [SerializeField, HideInInspector] //Serialize so it saves in the editor but hide it from showing up in the inspector window
    MeshFilter[] meshFilters;
    TerrainFace[] terrainFaces;

    Vector3[] directions = {Vector3.up,Vector3.down,Vector3.forward,Vector3.back,Vector3.left,Vector3.right}; //All of the cardinal directions

    private void OnValidate() //Update every time we change something in the editor
    {
        Initialise();
        GenerateMesh();
    }

    void Initialise()
    {
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

                meshObject.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObject.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            

            terrainFaces[i] = new TerrainFace(meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }

    void GenerateMesh()
    {
        foreach(TerrainFace terrainFace in terrainFaces)
        {
            terrainFace.ConstructMesh();
        }
    }

    
}
