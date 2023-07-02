using AYellowpaper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Quest : MonoBehaviour, ICompleteable
{
    [SerializeField] private bool _isVisible = true;
    [SerializeField] private Item[] _questItems;
    [SerializeField] private InterfaceReference<ICompleteable,MonoBehaviour>[] _questSteps;

    private Inventory _inventory;
    private TMP_Text _questPresenter;

    private bool _isCompleted;
    public Action OnCompleted { get; set; }
    public bool IsCompleted
    {
        get => _isCompleted;
        private set
        {
            _isCompleted = value;
            if (_isCompleted)
            {
                _inventory.OnInventoryChanged -= UpdateStatus;
                OnCompleted?.Invoke();
            }
        }
    }

    private void Awake()
    {
        _questPresenter = GetComponent<TMP_Text>();
        OnCompleted += () => _questPresenter.fontStyle = FontStyles.Strikethrough;
    }

    public void Start()
    {
        _inventory = Root.Instance.Player.Inventory;
        _inventory.OnInventoryChanged += UpdateStatus;
        foreach (var _questStep in _questSteps)
        {
            _questStep.Value.OnCompleted += UpdateStatus;
        }
        if(_isVisible)
        {
            Root.Instance.QuestList.AddQuest(this);
        }
    }

    private void UpdateStatus()
    {
        bool isCompleted = true;
        isCompleted = isCompleted && _questSteps.All(x => x.Value.IsCompleted == true);
        isCompleted = isCompleted && _inventory.CheckEquipped(_questItems);
        IsCompleted = isCompleted;
    }
}
