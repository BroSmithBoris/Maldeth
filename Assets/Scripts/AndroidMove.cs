using UnityEngine;

public class AndroidMove : MonoBehaviour
{
    private Vector3 startPos;
    public Camera cam;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startPos = cam.ScreenToViewportPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float posX = cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x;
            float posZ = cam.ScreenToViewportPoint(Input.mousePosition).y - startPos.y;
            transform.position = new Vector3(transform.position.x - posX, transform.position.y, transform.position.z - posZ);
        }
    }
}
