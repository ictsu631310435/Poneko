using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBowl : MonoBehaviour
{
    [SerializeField]
    private Sprite _emptyState;

    [SerializeField]
    private Sprite _fullState;

    [field: SerializeField]
    public float RestoreHunger { get; private set; }

    [field: SerializeField]
    public bool IsFull { get; set; }

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFullness(bool value)
    {
        IsFull = value;

        switch (value)
        {
            case true:
                _spriteRenderer.sprite = _fullState;
                break;

            case false:
                _spriteRenderer.sprite = _emptyState;
                break;
        }
    }
}
