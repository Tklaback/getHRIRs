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
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 hitPosition = hit.point;
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                hits.Add(hitPosition);
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
