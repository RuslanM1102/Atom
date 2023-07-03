using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] Item.ItemType _slotType;
    [SerializeField] Item _item;
    public Item Item { get => _item; }

    public void Awake()
    {
        if(_item != null)
        {
            if(_item.Type != _slotType && _slotType != Item.ItemType.Any)
            {
                _item = null;
            }
        }
    }

    public void Drop()
    {
        if(_item == null)
        {
            return;
        }

        Vector3 playerPosition = Root.Instance.Player.PlayerPosition;
        Quaternion playerRotation = Root.Instance.Player.PlayerRotation;

        var spawned = Instantiate(_item.Presenter);
        spawned.Init(_item);
        spawned.transform.position = playerPosition + playerRotation * Vector3.forward;
        spawned.transform.rotation = playerRotation;
        _item = null;
    }

    public void DestroyItem()
    {
        _item = null;
    }

    public bool TryPickup(Item item)
    {
        if (_item != null)
        {
            return false;
        }

        if (item.Type == _slotType || _slotType == Item.ItemType.Any)
        {
            _item = item;
            return true;
        }

        return false;
    }
}
