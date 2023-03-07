using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBallScript : MonoBehaviour
{
    public Transform destinantionPoint;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        transform.position = destinantionPoint.position;
    }
}
