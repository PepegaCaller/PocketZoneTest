using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform background; 
    public RectTransform handle;     
    public Vector2 inputDirection;  

    private float joystickRadius;

    void Start()
    {
        joystickRadius = background.sizeDelta.x / 2;
    }

    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            eventData.position,
            eventData.pressEventCamera,
            out position
        );
        inputDirection = position.magnitude > joystickRadius ? position.normalized : position / joystickRadius;
        handle.anchoredPosition = inputDirection * joystickRadius;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData); 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDirection = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}