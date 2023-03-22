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
    public bool canInteract = true;

    public bool isOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        clickCounter = roots.Length;
    }

    private void OnMouseEnter()
    {
        isOver = true;
    }

    private void OnMouseExit()
    {
        isOver = false;
    }

    public void ActivateRoots(int chance)
    {
        if (Random.Range(0, 100) < chance && canInteract)
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
        if(!canInteract & Input.GetMouseButtonDown(1) && isOver)
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
