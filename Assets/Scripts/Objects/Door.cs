using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Door : InteractableObject
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationAmount = 90f;
    [SerializeField] private bool _isRight = false;

    private bool _isOpen = false;
    private bool _isRotating = false;
    private float _time;
    private Vector3 _startRotation;
    private Quaternion _endRotation;
    private IEnumerator _stateCoroutine;
    private Rigidbody _rigidbody;


    private void Start()
    {
        _startRotation = transform.rotation.eulerAngles;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private int RotateModifier
    {
        get
        {
            int openModifier =_isOpen ? 1 : -1;
            int positionModifier = _isRight ? 1 : -1;
            return openModifier * positionModifier;
        }
    }

    public override void Interact()
    {
        if (_isRotating)
        {
            StopCoroutine(_stateCoroutine);
            _isRotating = false;
            _time = 1 - _time;
        }
        else
        {
            _time = 0;
        }
        _isOpen = !_isOpen;

        _stateCoroutine = ChangeState();
        StartCoroutine(_stateCoroutine);
    }

    private IEnumerator ChangeState()
    {
        _isRotating = true;

        var rotationVector = _startRotation;
        float x = rotationVector[0];
        float y = rotationVector[1];
        float z = rotationVector[2];

        if (_isOpen)
        {
            y += _rotationAmount * RotateModifier;
        }

        _endRotation = Quaternion.Euler(x, y, z);


        Vector3 rotation = new Vector3(0, _rotationAmount * RotateModifier, 0);
        while (Quaternion.Angle(_endRotation, transform.rotation) > 1)
        {
            Quaternion deltaRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime * _speed);
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
            yield return null;
        }

        transform.rotation = _endRotation;
        _isRotating = false;      
    }
}

