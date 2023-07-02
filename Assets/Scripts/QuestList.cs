using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuestList : MonoBehaviour
{
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
