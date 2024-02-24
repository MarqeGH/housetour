using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    GameObject crosshairs;
    // Start is called before the first frame update
    void Start()
    {
        crosshairs = GameObject.Find("Crosshairs");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - crosshairs.transform.position);
        
    }
}
