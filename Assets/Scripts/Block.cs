using AYellowpaper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Quest[] _questList;

    public void Start()
    {
        foreach(Quest quest in _questList)
        {
            quest.OnCompleted += TryDelete;
        }
    }

    private void TryDelete()
    {
        if(_questList.All(x => x.IsCompleted))
        {
            gameObject.SetActive(false);
        }
    }
}
