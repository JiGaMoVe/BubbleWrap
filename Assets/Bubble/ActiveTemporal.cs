using UnityEngine;
using UnityEngine.UI;

public interface IActive
{
    void Activate();
    void Deactivate();
}

[RequireComponent(typeof(Image))]
public class ActiveTemporal : MonoBehaviour, IActive
{
    private Image _image;
    private Color _initialColor;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
        _initialColor = _image.color;
    }
    
    public void Activate()
    {
        _image.color = Color.red;
    }

    public void Deactivate()
    {
        _image.color = _initialColor;
    }
}
