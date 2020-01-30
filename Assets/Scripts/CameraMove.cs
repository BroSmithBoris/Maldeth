using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    KeyCode up = KeyCode.W;
    KeyCode down = KeyCode.S;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;
    private Vector3 moveDirection = Vector3.zero;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        int x;
        int z;

        if (Input.GetKey(up))
            x = 1;
        else if (Input.GetKey(down))
            x = -1;
        else
            x = 0;

        if (Input.GetKey(left))
            z = -1;
        else if (Input.GetKey(right))
            z = 1;
        else
            z = 0;

        moveDirection = new Vector3(x, 0, z);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;

    }
}
