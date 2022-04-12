using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHitPosition : MonoBehaviour
{

    public GameObject Coords;
    private TextMesh txt;
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
            txt.text = hitPosition.ToString();
        }
        
    }
}
