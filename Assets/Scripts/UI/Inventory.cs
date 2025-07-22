using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    private List<ItemSlot> _inventory = new();
    private int _currentIndex = 0;
    
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _inventory.Add(transform.GetChild(i).GetComponent<ItemSlot>());
        }
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        float scroll = context.ReadValue<Vector2>().y;

        if (scroll == 0) return;

        ItemSlot old = _inventory[Mathf.Abs(_currentIndex)];

        if (scroll < 0)
        {
            _currentIndex--;
        } 
        else
        {
            _currentIndex++;
        }

        _currentIndex %= _inventory.Count;

        ItemSlot current = _inventory[Mathf.Abs(_currentIndex)];

        if (old != current)
        {
            old.Unselect();
            current.Select();
        }
    }
}
