using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class PhysicButton : InteractableObject, IOutlineable
{
    private Outline _outline;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    public override void Interact()
    {
        OnInteracted?.Invoke();
    }

    public void TurnHighlight()
    {
        _outline.enabled = !_outline.enabled;
    }
}
