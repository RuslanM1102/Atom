using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _maxUseDistance = 5f;

    private Transform _camera;
    private GameObject _currentObject;

    private void Awake()
    {
        _camera = Camera.main.transform;
    }
    private void OnUse()
    {
        if (Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit, _maxUseDistance))
        {
            if (hit.collider.TryGetComponent<DoorScript>(out DoorScript door))
            {
                    if (door.isOpen)
                    {
                        door.Close();
                    }
                    else
                    {
                        door.Open(transform.position);
                    }
            }

            if (hit.collider.TryGetComponent<InteractableObject>(out InteractableObject interactable))
            {
                interactable.Interact();
            }
        }
    }

}
