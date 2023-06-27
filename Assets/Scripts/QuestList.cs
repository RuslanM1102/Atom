using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    private List<Quest> _quests = new List<Quest>();
    
    public void AddQuest(Quest quest)
    {
        _quests.Add(quest);
    }
}
