
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    [SerializeField] private InventoryCell _cell;


    public void DeleteAnItem()
    {
        _cell.CurrentItem.Amount = 0;
        _cell. CurrentItem = null;
        _cell.Amount.text = "";
        _cell.UpdateCell();
        _cell.isDeleteActive = false;
        _cell.DeleteButton.gameObject.SetActive(_cell.isDeleteActive);
    }
}
