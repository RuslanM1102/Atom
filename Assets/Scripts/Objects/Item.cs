using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Wear,
        Boots,
        Accessory,
        Any
    }

    [SerializeField] private string _name;
    [SerializeField] private ItemType _type;
    [SerializeField] private ItemPresenter _presenter;
    public string Name { get => _name;}
    public ItemType Type { get => _type;}
    public ItemPresenter Presenter { get => _presenter;}
}
