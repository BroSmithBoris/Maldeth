using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    KeyCode Right = KeyCode.D;
    KeyCode Left = KeyCode.A;
    KeyCode Up = KeyCode.Q; 
    KeyCode Down = KeyCode.E;
    KeyCode Forward = KeyCode.W;
    KeyCode Back = KeyCode.S;
    private Vector3 moveDirectionLocal = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        int x;
        int yz;
        int z;

        if (Input.GetKey(Left))
            x = -1;
        else if (Input.GetKey(Right))
            x = 1;
        else
            x = 0;

        if (Input.GetKey(Up))
            yz = -1;
        else if (Input.GetKey(Down))
            yz = 1;
        else
            yz = 0;

        if (Input.GetKey(Forward))
            z = 1;
        else if (Input.GetKey(Back))
            z = -1;
        else
            z = 0;

        moveDirectionLocal = new Vector3(0, 0, yz);
        moveDirection = new Vector3(x, 0, z);

        moveDirectionLocal = transform.TransformDirection(moveDirectionLocal);
        moveDirection = (moveDirection + moveDirectionLocal) * speed;
        transform.position = transform.position + moveDirection * Time.deltaTime;

    }
}
