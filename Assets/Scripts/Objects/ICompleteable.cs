using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICompleteable
{
    public Action OnCompleted { get; set; }
    public bool IsCompleted { get;}
}
