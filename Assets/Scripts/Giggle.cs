using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class Giggle : MonoBehaviour
{
    private Renderer _renderer;
    private Vector3 point1;
    private bool _isMoving = false;
    private bool _isBackwards = false;
    public GameObject connectedObject;

    // Start is called before the first frame update
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        point1= new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
    }

    private void OnMouseDown()
    {

        _isMoving = true;
        if (enabled) { 
            RoomSwapManager.instance.canSwap = false;
        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, point1, 0.4f * Time.deltaTime * 100);
            if (transform.position == point1)
            {
                _isMoving = false;
                RoomSwapManager.instance.canSwap = true;
                connectedObject.transform.position = transform.position;
            }
        }
    }
}