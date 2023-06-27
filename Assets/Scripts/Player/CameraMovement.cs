using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _mouseSensivity = 2f;
    [SerializeField] private Transform _playerBody;
    private float _xRotate;
    private Vector3 _velocity = Vector3.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _xRotate = 0;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensivity;
        Vector3 playerRotation = _playerBody.rotation.eulerAngles;

        if (mouseY != 0f)
        {
            _xRotate -= mouseY;
            _xRotate = Mathf.Clamp(_xRotate, -90f, 90f);
        }

        if (mouseX != 0f)
        {
            _playerBody.Rotate(Vector3.up * mouseX);
            playerRotation = _playerBody.rotation.eulerAngles;
        }
        transform.rotation = Quaternion.Euler(_xRotate, playerRotation[1], playerRotation[2]);
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, 
            _playerBody.position + Vector3.up,ref _velocity, 5,
            Mathf.Infinity, Time.unscaledTime);
    }
}
