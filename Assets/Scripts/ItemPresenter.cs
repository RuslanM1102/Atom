using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPresenter : InteractableObject
{
    public override void Interact()
    {
        Destroy(gameObject);
        OnInteracted?.Invoke();
    }
}
