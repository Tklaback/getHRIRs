using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetHitPosition : MonoBehaviour
{
    private int cnt = 1;
    public GameObject Coords;
    private TextMesh txt;
    public List<Vector3> hits;
    
    // Start is called before the first frame update
    void Start()
    {
        Coords = GameObject.Find("Coords");
        txt = Coords.GetComponent<TextMesh>();
    }

    

    

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float z = transform.position.z + 1;
        Coords.transform.position = new Vector3(x, transform.position.y, z);
        Coords.transform.rotation = transform.rotation;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit))
        {

            GameObject hitObject = hit.transform.gameObject;

            Vector2 toVector = hit.transform.position - transform.position;

            //float angleToTarget = Vector2.Angle(transform.up, toVector);
            float yAngle = Mathf.Atan(hitObject.transform.position.y / hitObject.transform.position.x) * (180/Mathf.PI);

            //txt.text = hitObject.transform.position.ToString() + "\n" + yAngle;

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                Transform objectPos = hit.transform.GetComponent<Transform>();
                hits.Add(objectPos.position);
                txt.text = hits[cnt].ToString();
                hit.transform.gameObject.GetComponent<AudioSource>().Play();
                cnt++;
            }
            //else
            //{
            //    txt.text = hitPosition.ToString();
            //}

        }

    }

}
