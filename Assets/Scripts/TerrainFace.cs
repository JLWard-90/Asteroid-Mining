using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace
{ 
    Mesh mesh;
    int resolution; //The level of detail: The number of vertices along a single edge
    Vector3 localUp; //Which way it is facing
    Vector3 axisA; //axis perpendicular to localUp;
    Vector3 axisB; //axis perpendicular to localUp;
    ShapeGenerator shapeGenerator;

    public TerrainFace(ShapeGenerator shapeGenerator,Mesh mesh, int resolution, Vector3 localUp) //This is the constructor for the TerrainFace 
    {
        this.shapeGenerator = shapeGenerator;
        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;

        axisA = new Vector3(localUp.y,localUp.z,localUp.x);
        axisB = Vector3.Cross(localUp, axisA); //Perpendicular to both localUp and axisA
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[resolution*resolution]; //Store all vertices
        int[] triangles = new int[(resolution-1)*(resolution-1)*6]; //Int array to indeces of all triangles. size = resolution-1 squared(number of squares) * 2 (number of triangles per square) * 3 (number of vertices per triangle)
        int triIndex = 0;
        Vector2[] uv = mesh.uv;

        for (int y=0; y < resolution; y++)
        {
            for (int x=0; x<resolution; x++) //Iterate over entire face
            {
                int i = x+y*resolution;
                Vector2 percent = new Vector2(x,y) / (resolution-1); //Tells us how far through the loop we are
                Vector3 pointOnUnitCube = localUp + (percent.x-.5f)*2*axisA + (percent.y-.5f)*2*axisB;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;//used to go from a cube to a sphere
                vertices[i] = shapeGenerator.CalculatePointOnPlanet(pointOnUnitSphere);

                if(x!=resolution-1 && y!=resolution-1) //vertex is not along the right or bottom edges
                {
                    triangles[triIndex] = i; //Build the two triangles that make up a square by defining their 6 points (3 per triangle)
                    triangles[triIndex+1] = i+resolution+1;
                    triangles[triIndex+2] = i+resolution;

                    triangles[triIndex+3] = i;
                    triangles[triIndex+4] = i+1;
                    triangles[triIndex+5] = i+resolution+1;

                    triIndex += 6;
                }
            }
        }
        mesh.Clear(); //If we update with a lower resolution, then when we set mesh.vertices, mesh.triangles will reference vertices that no longer exist and will throw an error. Therefore we need to clear the mesh before setting the new vertices
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.uv = uv;
    }

    public void UpdateUVs(ColourGenerator colourGenerator)
    {
        Vector2[] uv = new Vector2[resolution * resolution];
        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++) //Iterate over entire face
            {
                int i = x + y * resolution;
                Vector2 percent = new Vector2(x, y) / (resolution - 1); //Tells us how far through the loop we are
                Vector3 pointOnUnitCube = localUp + (percent.x - .5f) * 2 * axisA + (percent.y - .5f) * 2 * axisB;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;//used to go from a cube to a sphere

                uv[i] = new Vector2(colourGenerator.BiomePercentFromPoint(pointOnUnitSphere),0);
            }
        }
        mesh.uv = uv;
    }
}
