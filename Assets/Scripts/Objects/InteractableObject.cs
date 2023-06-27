using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public Action OnInteracted { get; set; }
    public abstract void Interact();
}
