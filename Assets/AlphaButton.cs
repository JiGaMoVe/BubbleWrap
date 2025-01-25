using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlphaButton : MonoBehaviour, IPointerDownHandler
{
    private Image _image;
    private Texture2D _texture;
    
    public UnityEvent onClick = new();
    
    public bool Interactable
    {
        set => _image.raycastTarget = value;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        if (_image.sprite != null)
        {
            _texture = _image.sprite.texture;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_texture == null) return;

        var rectTransform = _image.rectTransform;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);

        var rect = rectTransform.rect;
        float x = (localPoint.x - rect.x) / rect.width;
        float y = (localPoint.y - rect.y) / rect.height;

        int texX = Mathf.FloorToInt(x * _texture.width);
        int texY = Mathf.FloorToInt(y * _texture.height);

        var color = _texture.GetPixel(texX, texY);

        if (color.a > 0f)
        {
            onClick.Invoke();
        }
    }
}