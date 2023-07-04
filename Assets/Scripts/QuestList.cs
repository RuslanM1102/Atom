using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class QuestList : MonoBehaviour
{
    public Action OnQuestEnded;
    private List<Quest> _quests = new List<Quest>();
    public void AddQuest(Quest quest)
    {
        _quests.Add(quest);
        quest.OnCompleted += CheckAll;
    }

    private void CheckAll()
    {
        if (_quests.All(x => x.IsCompleted))
        {
            OnQuestEnded?.Invoke();
        }
    }
}
