
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Item CurrentItem;
    public Image Image;
    public TMP_Text Amount;
    public Button DeleteButton;
    public bool isDeleteActive = false;

    [SerializeField] private bool _isDragging;
    [SerializeField] private bool _isEntered;

    
    public void UpdateCell()
    {
        if( CurrentItem && CurrentItem.Icon && CurrentItem.Amount>=0)
        {
            Image.sprite = CurrentItem.Icon;
            Image.color = Color.white;
            
            if (CurrentItem.Amount > 1)
            {
                Amount.text = CurrentItem.Amount.ToString();
            }
            else if (CurrentItem.Amount==1)
            {
                
                Amount.text = "";
            }
            else
            {
                Image.sprite = null;
                Image.color = Color.clear;
            }
            
        }
        else
        {
            Image.sprite = null;
            Image.color = Color.clear;
        }
    }

    public void RemoveItem()
    {
        
        if (CurrentItem.Amount > 1 && CurrentItem!=null)
        {
            CurrentItem.Amount--;
            Amount.text = CurrentItem.Amount.ToString();
        }
        else if (CurrentItem.Amount==1)
        {
            CurrentItem.Amount--;
            Amount.text = "";
        }
        else
        {
            CurrentItem.Amount--;
            CurrentItem = null;
        }
        UpdateCell();

    }

    public void DeleteItem()
    {
        if (CurrentItem != null)
        {
            CurrentItem = null;
            Amount.text = "";
        }
        
        UpdateCell();
    }
    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDragging = true;
        InventoryManager.Instance.IsDraggingItem = true;
        InventoryManager.Instance.DraggingCell = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (_isDragging&&InventoryManager.Instance.EnteredCell)
        {
            Item item = InventoryManager.Instance.EnteredCell.CurrentItem;
            InventoryManager.Instance.EnteredCell.CurrentItem = CurrentItem;
            CurrentItem = item;
            InventoryManager.Instance.IsDraggingItem = false;
            InventoryManager.Instance.DraggingCell = null;
            InventoryManager.Instance.EnteredCell = null;
            _isDragging = false;
        }
        else if (_isDragging)
        {
            InventoryManager.Instance.IsDraggingItem = false;
            InventoryManager.Instance.DraggingCell = null;
            InventoryManager.Instance.EnteredCell = null;
            _isDragging = false;
        }
        Amount.text = "";
        InventoryManager.Instance.UpdateCells();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isEntered = true;
        InventoryManager.Instance.EnteredCell = this;
        
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        _isEntered = false;
        InventoryManager.Instance.EnteredCell = null;
        
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CurrentItem && CurrentItem.Icon)
        {
            isDeleteActive = !isDeleteActive;
            DeleteButton.gameObject.SetActive(isDeleteActive);
        }
    }

    void Start()
    {
        Image = GetComponentsInChildren<Image>()[1];
        UpdateCell();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && _isEntered)
        {
            RemoveItem();
        }
        if (Input.GetKeyDown(KeyCode.T) && _isEntered)
        {
            DeleteItem();
        }
    }
}
