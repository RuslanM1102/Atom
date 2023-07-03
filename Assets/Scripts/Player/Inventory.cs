using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

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
            ctx => DropEquippedItem((int)ctx.ReadValue<float>());
        _playerInput.actions["UseItem"].performed +=
            ctx => UseItem();
        _playerInput.actions["DropItem"].performed +=
    ctx => DropItem();

        for (int i = 0; i < _slots.Length; i++)
        {
            _ui.SetSlot(i, _slots[i].Item);
        }
    }

    private void UseItem()
    {
        if(_slots[0].Item == null)
        {
            return;
        }

        if (TryPickupItem(_slots[0].Item))
        {
            _slots[0].DestroyItem();
            OnItemDrop?.Invoke(0);
        }
    }
    private void DropItem()
    {
        if (_slots[0].Item == null)
        {
            return;
        }

        _slots[0].Drop();
        OnItemDrop?.Invoke(0);
    }

    public Item MoveToStorage()
    {
        if (_slots[0].Item == null)
        {
            return null;
        }
        var item = _slots[0].Item;
        _slots[0].DestroyItem();
        OnItemDrop?.Invoke(0);
        return item;
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

    private void DropEquippedItem(int id)
    {
        _slots[id].Drop();
        OnItemDrop?.Invoke(id);
    }

    public bool CheckEquipped(Item[] items, bool isStrict)
    {
        bool isEquipped = true;
        List<Item> myItems = GetItems();
        foreach (Item item in items)
        {
            isEquipped = isEquipped && myItems.Any(x => x == item);
        }
        if (isStrict)
        {
            var a = myItems.Except(items).ToList();
            isEquipped = isEquipped &&
                myItems.Except(items)
                .Where(x => x != null).Count() == 0;
        }
        return isEquipped;
    }

    public List<Item> GetItems()
    {
        List<Item> items = new List<Item>();
        for (int i = 1; i < _slots.Length; i++)
        {
            items.Add(_slots[i].Item);
        }

        return items;
    }
}