using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    private bool isRotating = false;
    public float lowerBound;
    public float upperBound;
    public RotateOnClick other;
    public bool isSet = false;
    private void OnMouseDown()
    {
        isRotating = true;
        RoomSwapManager.instance.canSwap = false;
    }

    private void OnMouseUp()
    {
        if (!other.isRotating || !isSet)
        {
            isRotating = false;
            RoomSwapManager.instance.canSwap = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.up, -.25f * Time.deltaTime * 100);
            Debug.Log(transform.rotation.eulerAngles.x);
            if (transform.rotation.eulerAngles.x >= lowerBound && transform.rotation.eulerAngles.x <= upperBound)
            {
                isSet = true;
                if (other.isSet)
                {
                    isRotating = false;
                }
            }
            else
            {
                isSet = false;
            }
        }
        
    }
}
