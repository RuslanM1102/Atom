using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : InteractableObject
{
    [SerializeField] private ItemPresenter _item;
    public override void Interact()
    {
        var spawned = Instantiate(_item);
        spawned.transform.position = transform.position + transform.rotation * Vector3.back;
        spawned.transform.rotation = transform.rotation;
        OnInteracted?.Invoke();
    }
}
