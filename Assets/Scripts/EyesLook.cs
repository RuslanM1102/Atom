using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesLook : MonoBehaviour
{
    [SerializeField] private float MouseSensivity = 2f;
    [SerializeField] private Transform playerBody;
    private float xRotate;
    public static bool _isBlocked = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        xRotate = 0;
    }

    private void Update()
    {
        if (_isBlocked)
        {
            return;
        }
        else
        {
            float mouseX = Input.GetAxis("Mouse X") * MouseSensivity;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensivity;

            if (mouseY != 0f)
            {
                xRotate -= mouseY;
                xRotate = Mathf.Clamp(xRotate, -90f, 90f);
                transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
            }

            if (mouseX != 0f)
            {
                playerBody.Rotate(Vector3.up * mouseX);
            }
        }
    }
}
