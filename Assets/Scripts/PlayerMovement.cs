using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private CharacterController _characterController;
    private Vector3 _velocity;

    [SerializeField] private Animator _scrollAnim;
    private bool _isAnim = false;
    public static bool _isBlocked = false;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_isBlocked)
        {
            return;
        }
        else
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (x != 0 || z != 0)
            {
                Vector3 move = transform.right * x + transform.forward * z;
                _characterController.Move(move * _speed * Time.deltaTime);
            }

            if (Physics.CheckSphere(Vector3.zero, 0.2f))
            {
                _velocity.y += Physics.gravity.y * Time.deltaTime;
                _characterController.Move(_velocity * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Tab) && !_isAnim)
            {
                _scrollAnim.Play("TAB", 0, 0.0f);
                _isAnim = true;
            }
            else if (Input.GetKeyDown(KeyCode.Tab) && _isAnim)
            {
                _scrollAnim.Play("IdleTAB", 0, 0.0f);
                _isAnim = false;
            }
        }
    }
}
