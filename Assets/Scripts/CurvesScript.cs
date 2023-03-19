using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CurvesScript : MonoBehaviour
{
    public GameObject[] roots;

    private int clickCounter = 0;
    private bool canInteract = true;
    
    // Start is called before the first frame update
    void Start()
    {
        clickCounter = roots.Length;
    }

    // Update is called once per frame
    private void OnMouseDrag()
    {
        if (canInteract)
        {
            transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
        }

    }


    public void ActivateRoots(int chance)
    {
        if (Random.Range(0, 100) < chance)
        {
            canInteract = false;
            foreach (var root in roots)
            {
                root.gameObject.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if(!canInteract & Input.GetMouseButtonDown(1))
        {
            roots[clickCounter - 1].SetActive(false);
            clickCounter--;
            if (clickCounter == 0)
            {
                canInteract = true;
                clickCounter = roots.Length;
            }
        }
    }
}
