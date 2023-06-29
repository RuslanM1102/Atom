using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class ItemPresenter : InteractableObject, IOutlineable
{
    private Outline _outline;
    private Item _item;

    public void Init(Item item)
    {
        _item = item;
    }

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    public override void Interact()
    {
        if (Root.Instance.Player.Inventory.TryPickupItem(_item))
        {
            Destroy(gameObject);
        }

        OnInteracted?.Invoke();
    }

    public void TurnHighlight()
    {
        _outline.enabled = !_outline.enabled;
    }
}
