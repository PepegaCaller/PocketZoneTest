using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveNLoad : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    public void SavePlayer()
    {
        BinarySavingSystem.SavePlayer(_playerHealth);
    }
    public void LoadPlayer()
    {
        PlayerData data = BinarySavingSystem.LoadPlayer();
        _playerHealth.currentHealth = data.health;
        InventoryManager.Instance.ClearInventory();
        for (int i = 0; i < (InventoryManager.Instance.HorizontalCellsCount * InventoryManager.Instance.VerticalCellsCount); i++)
        {
            if (data.inventoryNames[i] != "null" && data.inventoryNames[i]!=null)
            {
                string buf = data.inventoryNames[i];
                Item item = Resources.Load<Item>(buf);
                item.Amount = data.inventoryAmount[i];
                InventoryManager.Instance.SetCurrentItem(i, item);
                
            }
           
        }
        InventoryManager.Instance.UpdateCells();


    }
}
