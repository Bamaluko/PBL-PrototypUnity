using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwapManager : MonoBehaviour
{
    public static RoomSwapManager instance;
    public bool canSwap = true;
    public GameObject brightWorld;
    public GameObject darkWorld;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canSwap)
        {
            brightWorld.SetActive(!brightWorld.activeSelf);
            darkWorld.SetActive(!darkWorld.activeSelf);
        }
    }
}
