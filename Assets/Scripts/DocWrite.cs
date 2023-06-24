using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocWrite : InteractableObject
{
    private SpriteRenderer _objSprite;
    [SerializeField] private Sprite _sprite;

    private void Awake()
    {
        _objSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    public override void Interact()
    {
        _objSprite.sprite = _sprite;

        OnInteracted?.Invoke();

    }
}
