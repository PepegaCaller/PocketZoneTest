using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int VerticalCellsCount = 3;
    public int HorizontalCellsCount = 4;
    public List<InventoryCell> inventoryCells = new List<InventoryCell>();
    public static InventoryManager Instance;
    public InventoryCell EnteredCell;
    public InventoryCell DraggingCell;
    public bool IsDraggingItem;

    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _itemPrefab;

    [Header("Test")]
    public Item TestItem;
 
    public void Initialize()
    {
        Instance = this;
        FillInventory();
        AddItemAmount(TestItem, 30);
        
    }

    public void UpdateInvetoryManager()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {

            AddItem(TestItem);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {

            ClearInventory();
        }


    }
    public void FillInventory()
    {
        for (int i = 0; i< VerticalCellsCount * HorizontalCellsCount; i++)
        {
            InventoryCell cell = Instantiate(_itemPrefab, _content).GetComponent<InventoryCell>();
            inventoryCells.Add(cell);
        }
    }

    
    public void AddItemAmount(Item item, int amount)
    {
        if (inventoryCells[0].CurrentItem == null)
        {
            Tuple<bool, int> tuple = GetFreeCell();
            if (tuple.Item1)
            {
                inventoryCells[tuple.Item2].CurrentItem = item;
                inventoryCells[FindItemByName(item)].CurrentItem.Amount= amount;
                UpdateCells();
            }
        }
        else if (FindItemByName(item) >= 0 && inventoryCells[FindItemByName(item)].CurrentItem.IsStackable == true)
        {
            inventoryCells[FindItemByName(item)].CurrentItem.Amount=amount;
            UpdateCells();

        }
        else 
        {
            Tuple<bool, int> tuple = GetFreeCell();
            if (tuple.Item1)
            {
                inventoryCells[tuple.Item2].CurrentItem = item;
                inventoryCells[FindItemByName(item)].CurrentItem.Amount = amount;
                UpdateCells();
            }
        }
    }

    public void AddItem(Item item)
    {
        if (inventoryCells[0].CurrentItem==null && FindItemByName(item)<0)
        {
            Tuple<bool, int> tuple = GetFreeCell();
            if (tuple.Item1)
            {
                inventoryCells[tuple.Item2].CurrentItem = item;
                inventoryCells[FindItemByName(item)].CurrentItem.Amount++;
                UpdateCells();
            }
        }
        else if(FindItemByName(item)>=0 && inventoryCells[FindItemByName(item)].CurrentItem.IsStackable==true)
        {
            inventoryCells[FindItemByName(item)].CurrentItem.Amount++;
            UpdateCells();
            
        }
        else
        {
            Tuple<bool, int> tuple = GetFreeCell();
            if (tuple.Item1)
            {
                inventoryCells[tuple.Item2].CurrentItem = item;
                inventoryCells[FindItemByName(item)].CurrentItem.Amount++;
                UpdateCells();
            }
        }
    }

    public void SetCurrentItem(int pos, Item item)
    {
        inventoryCells[pos].CurrentItem = item;
    }
    public int FindItemByName(Item item) //placement in an inventory array;
    {
        for(int i =0; i< inventoryCells.Count; i++)
        {
            if (inventoryCells[i].CurrentItem!=null&& inventoryCells[i].CurrentItem.Name == item.Name)
            {
                return i;
            }
        }
        return -1;
    }
    public void UpdateCells()
    {
        for(int i =0; i <inventoryCells.Count; i++)
        {
            inventoryCells[i].UpdateCell();
        }
    }
    public List<string> GetInventoryNames()
    {
        List<string> currentInventoryNames = new List<string>();
        for (int i = 0; i < inventoryCells.Count; i++)
        {
            if (inventoryCells[i].CurrentItem == null)
            {
                currentInventoryNames.Add("null");
                Debug.Log("null");
            }
            else
            {
                currentInventoryNames.Add(inventoryCells[i].CurrentItem.Name);
                Debug.Log(inventoryCells[i].CurrentItem.Name);
            }
            
        }
        return currentInventoryNames;
    }

    public List<int> GetInventoryAmount()
    {
        List<int> currentInventoryAmount = new List<int>();
        for (int i = 0; i < inventoryCells.Count; i++)
        {
            if (inventoryCells[i].CurrentItem == null)
            {
                currentInventoryAmount.Add(0);
                Debug.Log("0");
            }
            else
            {
                currentInventoryAmount.Add(inventoryCells[i].CurrentItem.Amount);
                Debug.Log(inventoryCells[i].CurrentItem.Amount);
            }

        }
        return currentInventoryAmount;
    }
    public void ClearInventory()
    {
        for (int i = 0; i < inventoryCells.Count; i++)
        {
            inventoryCells[i].DeleteItem();
        }
    }
    private Tuple<bool, int> GetFreeCell()
    {
        for (int i = 0; i < inventoryCells.Count; i++)
        {
            if (inventoryCells[i].CurrentItem == null)
            {
                return Tuple.Create(true, i);
            }
        }
        return Tuple.Create(false, 0);
    }
}
