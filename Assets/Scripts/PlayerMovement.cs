using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _gravity = -15.81f;

    Vector3 velocity;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private float _groundDist = 0.4f;
    [SerializeField]
    private LayerMask _groundMask;
    bool isGrounded;

    [SerializeField]
    private CharacterController characterController;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDist, _groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * _speed * Time.deltaTime);

        velocity.y += _gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
