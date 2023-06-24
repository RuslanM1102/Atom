using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationAmount = 90f;
    [SerializeField] private bool _isRight = false;

    private bool _isOpen = false;
    private bool _isRotating = false;
    private float _time;
    private Vector3 _startRotation, _endRotation;
    private IEnumerator _stateCoroutine;

    private void Start()
    {
        _startRotation = transform.rotation.eulerAngles;
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

        PlayerInteract.text1.fontStyle = TMPro.FontStyles.Strikethrough;
        _stateCoroutine = ChangeState();
        StartCoroutine(_stateCoroutine);
    }

    private IEnumerator ChangeState()
    {
        _isRotating = true;
        float speed = (1 - _time) * _speed;
        while (_time < 1)
        {
            float rotation = _rotationAmount * Time.deltaTime * _speed;
            transform.RotateAround(transform.position, Vector3.up, rotation * RotateModifier);
            _time += Time.deltaTime * _speed;
            yield return null;
        }
        var rotationVector = _startRotation;
        float x = rotationVector[0];
        float y = rotationVector[1];
        float z = rotationVector[2];

        if (_isOpen)
        {
            y += _rotationAmount * RotateModifier;
        }

        transform.rotation = Quaternion.Euler(x, y, z);
        _isRotating = false;      
    }
}

