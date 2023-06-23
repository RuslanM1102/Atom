using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Root : MonoBehaviour
{
    public static Root Instance { get; private set; }
    [SerializeField] private GameObject _UIInteract;

    public GameObject UIInteract { get => _UIInteract; }

    private void Awake()
    {
        Instance = this;
    }
}
