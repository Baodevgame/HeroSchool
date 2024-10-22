using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bgImage;
    private Image joystickImage;

    private Vector2 inputVector;

    public Vector2 Direction { get { return inputVector; } }
    public float Horizontal { get { return inputVector.x; } }
    public float Vertical { get { return inputVector.y; } }

    private void Start()
    {
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>(); // JoystickHandle

        // Debugging output to check if references are set
        if (bgImage == null)
        {
            Debug.LogError("bgImage is not assigned. Check if JoystickBackground has an Image component.");
        }

        if (joystickImage == null)
        {
            Debug.LogError("joystickImage is not assigned. Check if JoystickHandle has an Image component as a child.");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (bgImage == null || joystickImage == null) return; // Prevent further execution if references are null

        Vector2 position = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, eventData.position, eventData.pressEventCamera, out position);
        position.x = (position.x / bgImage.rectTransform.sizeDelta.x);
        position.y = (position.y / bgImage.rectTransform.sizeDelta.y);

        inputVector = new Vector2(position.x * 2 - 1, position.y * 2 - 1);
        inputVector = (inputVector.magnitude > 1) ? inputVector.normalized : inputVector;

        joystickImage.rectTransform.anchoredPosition = new Vector2(inputVector.x * (bgImage.rectTransform.sizeDelta.x / 2), inputVector.y * (bgImage.rectTransform.sizeDelta.y / 2));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickImage.rectTransform.anchoredPosition = Vector2.zero;
    }
}
