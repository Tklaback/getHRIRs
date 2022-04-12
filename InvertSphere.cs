using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;
        for (int num = 0; num<normals.Length; num++)
        {
            normals[num] = -1 * normals[num];
        }
        mesh.normals = normals;

        for (int num = 0; num < mesh.subMeshCount; num++)
        {
            int[] tris = mesh.GetTriangles(num);
            for (int triLength = 0; triLength < tris.Length; triLength += 3)
            {
                int temp = tris[triLength];
                tris[triLength] = tris[triLength + 1];
                tris[triLength + 1] = temp;
            }
            mesh.SetTriangles(tris, num);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
