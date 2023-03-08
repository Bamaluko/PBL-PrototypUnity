using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPuzzleFinisher : MonoBehaviour
{
    public static BallPuzzleFinisher instance;
    public  bool  ball1 = false;
    public  bool  ball2 = false;
    public  bool  ball3 = false;

    public GameObject plane;
    public Transform destination;
    private void Start()
    {
        if(instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball1 && ball2 && ball3)
        {
            plane.transform.position =
                Vector3.MoveTowards(plane.transform.position, destination.position, 0.4f * Time.deltaTime * 100);

        }
    }
}
