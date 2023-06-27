using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class ItemStorage : InteractableObject, IOutlineable
{
    [SerializeField] private ItemPresenter _item;
    private Outline _outline;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    public override void Interact()
    {
        var spawned = Instantiate(_item);
        spawned.transform.position = transform.position + transform.rotation * Vector3.back;
        spawned.transform.rotation = transform.rotation;
        OnInteracted?.Invoke();

    }

    public void TurnHighlight()
    {
        _outline.enabled = !_outline.enabled;
    }
}
