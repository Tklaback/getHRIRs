using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class TestSphere : MonoBehaviour
{
    public static Dictionary<Vector3, Vector2> coords;
    private float radius = 8f;
    private int elevAdded = -10;
    private int elevation = 0;
    private int azimuthAdded = 10;
    private int azimuth;
    private bool topCount = false, bottomCount = false; // Maybe use these variables to restrict how many squares get piled up on top and bottom
    // Start is called before the first frame update
    void Start()
    {
        coords = new Dictionary<Vector3, Vector2>();
        int angle = 10;
        
        for (int i = 0; i < 36; i++, angle += 10)
        {
            if (elevAdded > 0)
            {
                azimuth = -180;
            }
            else
                azimuth = 0;
            for (int num = 0; num < 18; num++)
            {
                transform.position += transform.forward * radius;
                if (elevation == -90)
                {
                    if (bottomCount == true)
                        continue;
                    else
                        bottomCount = true;
                }
                if (elevation == 90)
                {
                    if (topCount == true)
                        continue;
                    else
                        topCount = true;
                }
                GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (i == 0 && num == 0)
                {
                    var cubeRenderer = newCube.GetComponent<Renderer>();
                    cubeRenderer.material.SetColor("_Color", Color.red);
                }
                newCube.transform.position = transform.position;
                newCube.transform.rotation = transform.rotation;
                AudioSource newSource = newCube.AddComponent(typeof(AudioSource)) as AudioSource;
                newSource.playOnAwake = false;
                newSource.clip = Resources.Load("AudioClips/sfx_belt_in") as AudioClip;
                newSource.spatialBlend = 1;
                coords[transform.position] = new Vector2(elevation, azimuth);
                transform.position = new Vector3(0, 0, 0);
                transform.RotateAround(transform.position, Vector3.up, 10);

                
                azimuth += azimuthAdded;
                
            }
            if (Mathf.Abs(elevation) == 90)
            {
                elevAdded *= -1;
            }
                
            elevation += elevAdded;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
