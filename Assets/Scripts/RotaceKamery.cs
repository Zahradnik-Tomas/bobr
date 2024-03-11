using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaceKamery : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 otoc;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        otoc.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-otoc.y, 0, 0);
    }
}
