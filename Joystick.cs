using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform bg;
    public RectTransform handle;

    private Vector2 inputVector;

    public float Horizontal => inputVector.x;
    public float Vertical => inputVector.y;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            bg, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = pos.x / (bg.sizeDelta.x / 2);
            pos.y = pos.y / (bg.sizeDelta.y / 2);

            inputVector = new Vector2(pos.x, pos.y);
            inputVector = (inputVector.magnitude > 1) ? inputVector.normalized : inputVector;

            handle.anchoredPosition = new Vector2(
                inputVector.x * (bg.sizeDelta.x / 2),
                inputVector.y * (bg.sizeDelta.y / 2)
            );
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}