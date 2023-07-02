using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class ItemStorage : InteractableObject, IOutlineable
{
    [SerializeField] private Item[] _items;
    private Outline _outline;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    public override void Interact()
    {
        foreach (Item item in _items)
        {
            var spawned = Instantiate(item.Presenter);
            spawned.Init(item);
            spawned.transform.position = transform.position + transform.rotation * new Vector3(0,0,2);
            spawned.transform.rotation = transform.rotation;
        }
        OnInteracted?.Invoke();

    }

    public void TurnHighlight()
    {
        _outline.enabled = !_outline.enabled;
    }
}
