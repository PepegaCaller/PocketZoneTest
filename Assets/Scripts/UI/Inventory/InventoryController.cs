using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;

    private bool isOpen = false;
    public void ToggleInventory()
    {
        isOpen = !isOpen; 
        _inventory.SetActive(isOpen);
    }
}
