using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBallScript : MonoBehaviour
{
    public Transform destinantionPoint;
    public GameObject chest;
    
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        transform.position = destinantionPoint.position;
        RoomSwapManager.instance.ballsCollected++;
        if (RoomSwapManager.instance.ballsCollected >= 3)
        {
            chest.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
