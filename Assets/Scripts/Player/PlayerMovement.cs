using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Rigidbody _rigidbody;
    private Vector3 _velocity;
    private float _x, _z;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (_x != 0 || _z != 0)
        {
            Vector3 move = (transform.right * _x + transform.forward * _z);
            float speed = _speed;
            if (Physics.Raycast(transform.position, move, out RaycastHit hit, 0.3f))
            {
                Vector2 oldDirection = new Vector2(move.x, move.z);
                Vector2 newDirection = Vector2.Perpendicular(hit.normal);

                float angle = Vector2.Angle(oldDirection, newDirection);
                if (angle > 90)
                {
                    newDirection = -newDirection;
                }

                if (angle > 20 && angle < 160)
                {
                    speed *= Mathf.Abs(angle - 90) / 70;
                }
                move = new Vector3(newDirection.x, 0, newDirection.y);
            }
            _rigidbody.velocity = move * Time.fixedDeltaTime * speed;
        }
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(!gameObject.activeSelf);
    }
}