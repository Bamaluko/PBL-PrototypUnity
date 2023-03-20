using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjectAction : MonoBehaviour
{
    private CurvesScript _curvesScript;
    // Start is called before the first frame update
    void Start()
    {
        _curvesScript = GetComponentInParent<CurvesScript>();
    }
    
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && _curvesScript.canInteract)
        {
            transform.position = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
        }
    }
}
