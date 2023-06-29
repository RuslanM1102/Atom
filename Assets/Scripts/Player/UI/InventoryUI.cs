using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private SlotUI[] _slots = new SlotUI[3];

    public void SetSlot(int id, Item item)
    {
        _slots[id].SetItem(item);
    }

    public void SetSlot(int id) => SetSlot(id, null);
}
