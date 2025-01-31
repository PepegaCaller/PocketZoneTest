using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int[] inventoryAmount;
    public string[] inventoryNames;

    public PlayerData(PlayerHealth playerHealth)
    {
        this.health = playerHealth.currentHealth;
        int size = InventoryManager.Instance.VerticalCellsCount * InventoryManager.Instance.HorizontalCellsCount;
        inventoryNames = new string[size];
        List<string>invNames=InventoryManager.Instance.GetInventoryNames();
        for(int i=0; i<size; i++)
        {
            inventoryNames[i] = invNames[i];
        }
        inventoryAmount = new int[size];
        List<int> invAm = InventoryManager.Instance.GetInventoryAmount();
        for(int i = 0; i < size; i++)
        {
            inventoryAmount[i] = invAm[i];
        }
    }
}
