using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertSphere : MonoBehaviour
{
    public int size;
    // Start is called before the first frame update
    void Start()
    {
        
        //Mesh mesh = GetComponent<MeshFilter>().mesh;
        //Vector3[] normals = mesh.normals;
        //for (int num = 0; num < normals.Length; num++)
        //{
        //    normals[num] = -1 * normals[num];
        //}
        //mesh.normals = normals;

        //for (int num = 0; num < mesh.subMeshCount; num++)
        //{
        //    int[] tris = mesh.GetTriangles(num);
        //    for (int triLength = 0; triLength < tris.Length; triLength += 3)
        //    {
        //        int temp = tris[triLength];
        //        tris[triLength] = tris[triLength + 1];
        //        tris[triLength + 1] = temp;
        //    }
        //    mesh.SetTriangles(tris, num);
        //}
        //for (int i = 0; i < normals.Length; i++)
        //{
        //    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    Vector3 newNormal = normals[i];
        //    cube.transform.position = newNormal * size;
        //    cube.transform.localScale = new Vector3(2.3f, 2.3f, .01f);
        //    cube.transform.LookAt(new Vector3(0, 0, 0), cube.transform.up);
        //    AudioSource source = cube.AddComponent(typeof(AudioSource)) as AudioSource;
        //    source.playOnAwake = false;
        //    source.clip = Resources.Load("AudioClips/sfx_belt_in") as AudioClip;
        //    source.spatialBlend = 1;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
