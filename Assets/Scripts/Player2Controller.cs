using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed = 6f;
    public GameObject teleport;

    public bool teleportAllowed = false;

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0;
        float vertical = 0;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1f;
        }
        if (horizontal != 0 && vertical != 0)
        {
            float tempHorizontal = horizontal;
            horizontal *= Mathf.Abs(horizontal) / (Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            vertical *=  Mathf.Abs(vertical) / (Mathf.Abs(tempHorizontal) + Mathf.Abs(vertical));
        }

       
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.position -= direction * (speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightControl) && teleportAllowed)
        {
            transform.position = teleport.transform.position;
        }
    }
}