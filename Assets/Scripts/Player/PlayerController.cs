using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CameraMovement _camera;
    [SerializeField] GameObject _playerBody;

    public void TurnPlayer()
    {
        _camera.enabled = !_camera.enabled;
        _playerBody.SetActive(!_playerBody.activeSelf);
    }
}
