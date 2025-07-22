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
        GetCurrentSlot().Select();
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        float scroll = context.ReadValue<Vector2>().y;

        if (scroll == 0) return;

        ItemSlot old = GetCurrentSlot();

        if (scroll < 0)
        {
            _currentIndex--;

            if (_currentIndex == -1)
                _currentIndex = _inventory.Count - 1;
        } 
        else
        {
            _currentIndex++;
        }

        _currentIndex %= _inventory.Count;

        ItemSlot current = GetCurrentSlot();

        if (old != current)
        {
            old.Unselect();
            current.Select();
        }
    }

    private ItemSlot GetCurrentSlot()
    {
        return _inventory[_currentIndex];
    }

    public void OnRightMouseClick(InputAction.CallbackContext context)
    {
        if (GetCurrentSlot().IsEmpty()) return;

        print("ITEM USED!");
    }
}
