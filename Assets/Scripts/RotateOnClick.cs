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
    public GameObject clockPuzzle;
    private Vector3 destination;

    private void Start()
    {
        destination = new Vector3(clockPuzzle.transform.position.x, clockPuzzle.transform.position.y + 20.0f, clockPuzzle.transform.position.z);
    }

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

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.up, -.5f * Time.deltaTime * 100);
            if (transform.rotation.eulerAngles.x >= lowerBound && transform.rotation.eulerAngles.x <= upperBound)
            {
                isSet = true;
                if (other.isSet)
                {
                    isRotating = false;
                    GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 255, 255);
                    other.GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 255, 255);
                    transform.eulerAngles = new Vector3(
                        (lowerBound + upperBound) / 2,
                        transform.eulerAngles.y,
                        transform.eulerAngles.z
                    );
                    other.transform.eulerAngles = new Vector3(
                        (other.lowerBound + other.upperBound) / 2,
                        other.transform.eulerAngles.y,
                        other.transform.eulerAngles.z
                    );
                }
            }
            else
            {
                isSet = false;
            }
        }

        if (isSet && other.isSet)
        {
            clockPuzzle.transform.position = Vector3.MoveTowards(clockPuzzle.transform.position, destination, 0.4f * Time.deltaTime * 100);
        }
        
    }
}
