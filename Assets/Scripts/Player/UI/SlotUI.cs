using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class SlotUI : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void SetItem(Item item)
    {
        string name = item != null ? $"{item.Name}" : "Пусто";
        _text.text = name;
    }
}
