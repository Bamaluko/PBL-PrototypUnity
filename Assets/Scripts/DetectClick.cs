using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class DetectClick : MonoBehaviour
{
    public GameObject connectedObject;
    private Renderer _renderer;
    public Transform point1;
    private bool _isMoving = false;


    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        _isMoving = true;
        RoomSwapManager.instance.canSwap = false;
    }

    private void Update()
    {
        if (_isMoving)
        {
            if (transform.position == point1.position)
            {
                _isMoving = false;
                connectedObject.transform.position = transform.position;
                RoomSwapManager.instance.canSwap = true;
                connectedObject.GetComponent<Giggle>().enabled = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, point1.position, 0.4f * Time.deltaTime * 100);
        }
    }
}
