using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public Action<int, Item> OnItemPickup;
    public Action<int> OnItemDrop;
    public Action OnInventoryChanged;

    [SerializeField] Slot[] _slots = new Slot[3];
    private InventoryUI _ui;
    private PlayerInput _playerInput;

    private void Start()
    {
        _ui = Root.Instance.MainUI.InventoryUI;
        OnItemDrop += _ui.SetSlot;
        OnItemPickup += _ui.SetSlot;

        OnItemDrop += (id) => OnInventoryChanged?.Invoke();
        OnItemPickup += (id, item) => OnInventoryChanged?.Invoke();

        _playerInput = Root.Instance.Player.PlayerInput;
        _playerInput.actions["Inventory"].performed +=
            ctx => DropItem((int)ctx.ReadValue<float>() - 1);

        for (int i = 0; i < _slots.Length; i++)
        {
            _ui.SetSlot(i, _slots[i].Item);
        }
    }

    public bool TryPickupItem(Item item)
    {
        bool isPickuped = false;
        int id = 0;
        for (int i = 0; i < _slots.Length; i++)
        {
            isPickuped = _slots[i].TryPickup(item);
            if (isPickuped)
            {
                id = i;
                break;
            }
        }

        if(isPickuped)
        {
            OnItemPickup?.Invoke(id, item);
        }
        return isPickuped;
    }

    private void DropItem(int id)
    {
        _slots[id].Drop();
        OnItemDrop?.Invoke(id);
    }

    public bool CheckItems(Item[] items)
    {
        bool isItemsCollected = true;
        List<Item> myItems = GetItems();
        foreach(Item item in items)
        {
            isItemsCollected = isItemsCollected && myItems.Any(x => x == item);
        }
        return isItemsCollected;
    }

    public List<Item> GetItems()
    {
        List<Item> items = new List<Item>();
        foreach(Slot slot in _slots)
        {
            items.Add(slot.Item);
        }
        return items;
    }
}