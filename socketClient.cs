using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;






public class socketClient : MonoBehaviour
{
    static TcpListener listener = new TcpListener(IPAddress.Any, 65432);
    static TcpClient c;
    static NetworkStream n;
    float time = 0;
    float timeDelay = 1;
    Ray myRay;
    Vector3 eyes, direction;
    Vector3 bigger;
    GameObject previous;
    GameObject current;
  
    

    void Start()
    {
        listener.Start();
        c = listener.AcceptTcpClient();
        n = c.GetStream();
    }

    void Update()
    {

        eyes = GameObject.Find("CenterEyeAnchor").transform.position;
        direction = (GameObject.Find("RightHandAnchor").transform.position - eyes);

        RaycastHit hit;
     
        
        if (Physics.Raycast(eyes, direction, out hit))
            {
            current = hit.transform.gameObject;
            var cubeRenderer = hit.transform.gameObject.GetComponent<Renderer>();
            if (cubeRenderer.material.GetColor("_Color") == Color.white )
            {
                
                if (OVRInput.Get(OVRInput.Button.Two))
                {
                    if (current == previous)
                    {
                        bigger = new Vector3(0.01f, 0.01f, 0.01f);
                        hit.transform.localScale += bigger;
                        time += 1 * Time.deltaTime;
                        if (time >= timeDelay)
                        {
                            time = 0;
                            cubeRenderer.material.SetColor("_Color", Color.green);
                            Vector2 newPos = TestSphere.coords[hit.transform.position];
                            Transform objectPos = hit.transform.GetComponent<Transform>();
                            byte[] msg = Encoding.ASCII.GetBytes(newPos.ToString()); //vec.ToString()
                            n.Write(msg, 0, msg.Length);
                        }
                    }
                    else
                    {
                        previous.transform.localScale = new Vector3(1, 1, 1);
                    }
                }
  
                else
                {
                    previous = current;
                    hit.transform.localScale = new Vector3(1, 1, 1);
                    time = 0;
                }
            }
            else
            {
                hit.transform.localScale = new Vector3(1, 1, 1);
            }

        }



    }
    

  
}



