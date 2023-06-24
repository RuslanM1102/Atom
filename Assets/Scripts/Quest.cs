using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public void Start()
    {
        Tasks.quests.Add(this);
    }
    public bool IsReady { get; private set; }
    
    [SerializeField] private Item[] _necessaryItems;
}
