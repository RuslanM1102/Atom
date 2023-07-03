using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class ItemStorage : InteractableObject, IOutlineable
{
    [SerializeField] private List<Item> _items = new List<Item>();
    [SerializeField] private float _itemDistance = 1f;
    private Inventory _inventory;
    private Outline _outline;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    private void Start()
    {
        _inventory = Root.Instance.Player.Inventory;
    }

    public override void Interact()
    {
        if (_items.Count > 0)
        {
            foreach (Item item in _items)
            {
                var spawned = Instantiate(item.Presenter);
                spawned.Init(item);
                spawned.transform.position = transform.position + (transform.forward * _itemDistance);
                spawned.transform.rotation = transform.rotation;
            }
            _items.Clear();
            OnInteracted?.Invoke();
        }
        else
        {
            if (_inventory.MoveToStorage() is Item item)
            {
                _items.Add(item);
            }
        }
    }

    public void TurnHighlight()
    {
        _outline.enabled = !_outline.enabled;
    }
}
