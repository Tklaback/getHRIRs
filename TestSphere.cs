using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSphere : MonoBehaviour
{
    private float radius = 8f;

    // Start is called before the first frame update
    void Start()
    {
        int angle = 10;
        
        for (int i = 0; i < 36; i++, angle += 10)
        {          
            for (int num = 0; num < 18; num++)
            {
                transform.position += transform.forward * radius;
                GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newCube.transform.position = transform.position;
                newCube.transform.rotation = transform.rotation;
                AudioSource newSource = newCube.AddComponent(typeof(AudioSource)) as AudioSource;
                newSource.playOnAwake = false;
                newSource.clip = Resources.Load("AudioClips/sfx_belt_in") as AudioClip;
                newSource.spatialBlend = 1;
                transform.position = new Vector3(0, 0, 0);
                transform.RotateAround(transform.position, Vector3.up, 10);
            }
            
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
