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
            //Do things
        }
    }
}
