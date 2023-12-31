using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _maxUseDistance = 5f;

    private PlayerInput _playerInput;
    private Transform _camera;
    private GameObject _interactHintUI;
    private MonoBehaviour _currentObject;

    private MonoBehaviour CurrentObject
    {
        get => _currentObject;
        set
        {
            if (_currentObject != null &&
                _currentObject is IOutlineable oldOutlineable)
            {
                oldOutlineable.TurnHighlight();
            }

            _currentObject = value;
            if (_currentObject is IOutlineable newOutlineable)
            {
                newOutlineable.TurnHighlight();
            }
            _interactHintUI.SetActive(_currentObject != null);
        }
    }

    private void Start()
    {
        _playerInput = Root.Instance.Player.PlayerInput;
        _camera = Camera.main.transform;
        _interactHintUI = Root.Instance.MainUI.InteractHintUI;

        _playerInput.actions["Use"].performed += ctx => OnUse();
    }

    private void OnUse()
    {
        if(CurrentObject is InteractableObject interactable) 
        { 
            interactable.Interact();
        }
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit, _maxUseDistance))
        {
            if (hit.collider.TryGetComponent<InteractableObject>(out InteractableObject interactable))
            {
                CurrentObject = interactable;
            }
            else
            {
                CurrentObject = null;
            }
        }
        else
        {
            CurrentObject = null;
        }
    }
}
