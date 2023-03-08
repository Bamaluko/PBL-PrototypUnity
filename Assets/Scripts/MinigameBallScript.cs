using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MinigameBallScript : MonoBehaviour
{
    private Vector3 initialPosition;
    public LayerMask tLayers;
    private bool isDraging = false;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isDraging = false;
            transform.position = initialPosition;
        }
    }

    private void OnMouseDown()
    {
        isDraging = true;
    }

    private void OnMouseUp()
    {
        isDraging = false;
    }
    private void Update()
    {
        if (isDraging)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit t;
            if (Physics.Raycast(castPoint, out t, Mathf.Infinity, tLayers))
            {
                transform.position = new Vector3(t.point.x, t.point.y, transform.position.z);
            }
        }
    }
}
