using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : InteractableObject
{
    public static bool _permition = false;
    [SerializeField] private GameObject _talkCanvas;
    [SerializeField] private GameObject _UICanvas;
    public static bool _isBlocked = false;
    public override void Interact()
    {
        _isBlocked = true;
        PlayerInteract._isBlocked = _isBlocked;
        PlayerMovement._isBlocked = _isBlocked;
        EyesLook._isBlocked = _isBlocked;
        Cursor.lockState = CursorLockMode.None;
        _talkCanvas.SetActive(true);
        _UICanvas.SetActive(false);
        

        OnInteracted?.Invoke();

    }

    public void OnCick()
    {
        _isBlocked = false;
        PlayerInteract._isBlocked = _isBlocked;
        PlayerMovement._isBlocked = _isBlocked;
        EyesLook._isBlocked = _isBlocked;
        Cursor.lockState = CursorLockMode.Locked;
        _talkCanvas.SetActive(false);
        _UICanvas.SetActive(true);
        _permition = true;
    }
}
