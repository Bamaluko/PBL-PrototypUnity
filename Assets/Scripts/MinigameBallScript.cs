using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MinigameBallScript : MonoBehaviour
{
    private Vector3 initialPosition;
    public LayerMask tLayers;
    private bool isDraging;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = initialPosition;
        }
    }

    private void OnMouseDrag()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit t;
        if (Physics.Raycast(castPoint, out t, Mathf.Infinity, tLayers))
        {
            transform.position = new Vector3(t.point.x, t.point.y, transform.position.z);
        }
    }

    private void Update()
    {
        throw new NotImplementedException();
    }
}
