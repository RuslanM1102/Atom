using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _maxUseDistance = 5f;

    public static bool _isBlocked = false;
    private Transform _camera;
    private GameObject _UIInteract;
    private MonoBehaviour _currentObject;
    public TMP_Text text;
    public static TMP_Text text1;

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
            _UIInteract.SetActive(_currentObject != null);
        }
    }
    private void Start()
    {
        text1 = text;
        _camera = Camera.main.transform;
        _UIInteract = Root.Instance.UIInteract;
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
        if (_isBlocked)
        {
            return;
        }
        else
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
}
