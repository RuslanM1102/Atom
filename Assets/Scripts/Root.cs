using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Root : MonoBehaviour
{
    public static Root Instance { get; private set; }
    [SerializeField] private UIController _mainUI;
    [SerializeField] private PlayerController _player;
    [SerializeField] private QuestList _questList;

    public UIController MainUI { get => _mainUI; }
    public PlayerController Player { get => _player; }
    public QuestList QuestList { get => _questList; }

    private void OnEnable()
    {
        Instance = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
