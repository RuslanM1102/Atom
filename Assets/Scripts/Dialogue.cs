using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] private string _textDialogue;
    public string TextDialogue { get => _textDialogue; } 
}
