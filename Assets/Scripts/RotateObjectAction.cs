using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectAction : MonoBehaviour
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
            transform.Rotate(0.0f, 1.0f, 0.0f, Space.World);
        }
    }
    
}
