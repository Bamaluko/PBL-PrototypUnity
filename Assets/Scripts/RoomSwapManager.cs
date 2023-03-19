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
    public int buttonPuzzle = 0;

    public int ballsCollected = 0;

    public int rootChance = 20;
    public CurvesScript[] rootableObjects;
    

    private void Start()
    {
        instance = this;
        darkWorld.SetActive(true);
        darkWorld.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canSwap)
        {
            brightWorld.SetActive(!brightWorld.activeSelf);
            darkWorld.SetActive(!darkWorld.activeSelf);
            if (brightWorld.activeSelf)
            {
                foreach (var element in rootableObjects)
                {
                    element.ActivateRoots(rootChance);
                }
                rootChance++;
            }

        }
    }
}
