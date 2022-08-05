using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackHand : MonoBehaviour
{
    GameObject hand;
    Vector3 pos;
    GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        sphere = GameObject.Find("handSphere");
        sphere.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        hand = GameObject.Find("RightHandAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
   
        pos.z += 1;
        transform.position = hand.transform.position;
    }
}
