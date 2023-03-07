using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickScript : MonoBehaviour
{
    public Material material;
    private Renderer _renderer;
    public int id;
    public GameObject wall;
    public Transform destination;
    private void OnMouseDown()
    {
        if (RoomSwapManager.instance.buttonPuzzle != 4)
        {
            if (RoomSwapManager.instance.buttonPuzzle == id - 1)
            {
                _renderer.material.color = Color.cyan;
                RoomSwapManager.instance.buttonPuzzle += 1;
            }
            else
            {
                RoomSwapManager.instance.buttonPuzzle = 0;
            }
        }
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (RoomSwapManager.instance.buttonPuzzle < id)
        {
            _renderer.material.color = Color.green;
        }
        else if (RoomSwapManager.instance.buttonPuzzle >= 4)
        {
            if (wall != null)
            {
                wall.transform.position =
                    Vector3.MoveTowards(wall.transform.position, destination.position, 0.4f * Time.deltaTime * 100);
            }
        }
    }
}
