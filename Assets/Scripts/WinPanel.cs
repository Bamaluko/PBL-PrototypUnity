using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform destination;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, destination.position, 0.4f * Time.deltaTime * 100);
        }
    }
}
