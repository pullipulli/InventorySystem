using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] private GameObject character;
    private List<ItemSlot> _inventory = new();
    private int _currentIndex = 0;

    public Character Character { get => character.GetComponent<Character>(); }

    private ItemSlot GetCurrentSlot()
    {
        return _inventory[_currentIndex];
    }

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            ItemSlot item = transform.GetChild(i).GetComponent<ItemSlot>();
            _inventory.Add(item);
            item.InventoryIndex = i;
        }
        GetCurrentSlot().GetItemUI().Select();
    }

    // this method is used to loop the through the slots in the inventory
    public void ChangeSelectedSlot(float direction)
    {
        if (direction == 0) return;

        ItemSlot old = GetCurrentSlot();

        if (direction < 0)
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
            old.GetItemUI().Unselect();
            current.GetItemUI().Select();
        }
    }

    public void UseSelectedItem()
    {
        ItemUI itemUI = GetCurrentSlot().GetItemUI();
        if (itemUI.IsEmpty()) return;

        itemUI.Preview.GetComponent<Item>().UseItem(Character, () => itemUI.RemoveItem() );
    }

    public void SwapItems(ItemSlot item1,  ItemSlot item2)
    {
        int temp = item1.InventoryIndex;

        _inventory[item1.InventoryIndex] = item2;
        _inventory[item2.InventoryIndex] = item1;
        item1.InventoryIndex = item2.InventoryIndex;
        item2.InventoryIndex = temp;

        if (item1.GetItemUI().IsSelected)
        {
            item1.GetItemUI().Unselect();
            item2.GetItemUI().Select();
        }
        else if (item2.GetItemUI().IsSelected)
        {
            item2.GetItemUI().Unselect();
            item1.GetItemUI().Select();
        }
    }

    public void DropSelectedItem()
    {
        ItemUI itemUI = GetCurrentSlot().GetItemUI();
        if (itemUI.IsEmpty()) return;

        GameObject itemToDrop = itemUI.Preview;

        itemToDrop.GetComponent<Item>().DropItem();
        itemUI.RemoveItem();
    }

    public void InsertItemInFirstFreeSlot(Item item)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].GetItemUI().IsEmpty())
            {
                _inventory[i].GetItemUI().SetItem(item);
                return;
            }
        }
        print("Inventory is full!");
    }
}
