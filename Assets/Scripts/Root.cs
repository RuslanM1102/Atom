using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Root : MonoBehaviour
{
    public static Root Instance { get; private set; }
    [SerializeField] private UIController _mainUI;
    [SerializeField] private PlayerController _player;

    public UIController MainUI { get => _mainUI; }
    public PlayerController Player { get => _player; }

    private void Awake()
    {
        Instance = this;
    }
}
