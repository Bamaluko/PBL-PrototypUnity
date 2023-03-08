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
    public Transform destination;
    public Color color;
    public int id = 0;

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

        if (Vector2.Distance(transform.position, destination.position) <= 3)
        {
            GetComponent<Renderer>().material.color = color;
            if (id == 1)
            {
                BallPuzzleFinisher.instance.ball1 = true;
            }
            else if (id == 2)
            {
                BallPuzzleFinisher.instance.ball2 = true;
            }
            else if (id == 3)
            {
                BallPuzzleFinisher.instance.ball3 = true;
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.blue;
            if (id == 1)
            {
                BallPuzzleFinisher.instance.ball1 = false;
            }
            else if (id == 2)
            {
                BallPuzzleFinisher.instance.ball2 = false;
            }
            else if (id == 3)
            {
                BallPuzzleFinisher.instance.ball3 = false;
            }
        }
    }
}
