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
    [SerializeField] private Item[] _questItems;
    [SerializeField] private InterfaceReference<ICompleteable,MonoBehaviour>[] _questSteps;

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
        foreach(var _questStep in _questSteps)
        {
            _questStep.Value.OnCompleted += UpdateStatus;
        }

        Root.Instance.QuestList.AddQuest(this);
    }

    private void UpdateStatus()
    {
        if (_questSteps.Where(x => x.Value.IsCompleted == false)
            .Count() == 0)
        {
            IsCompleted = true;
        }
    }
}
