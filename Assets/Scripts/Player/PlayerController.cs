using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private CameraMovement _camera;
    [SerializeField] private PlayerMovement _playerBody;
    [SerializeField] private Inventory _inventory;
    private PlayerInput _playerInput;
    public PlayerInput PlayerInput { get => _playerInput;}
    public Quaternion PlayerRotation { get => _playerBody.transform.rotation; }
    public Vector3 PlayerPosition { get => _playerBody.transform.position; }
    public Inventory Inventory { get => _inventory;}

    public void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void TurnPlayer()
    {
        _playerBody.Stop();
        _camera.enabled = !_camera.enabled;
    }
}
