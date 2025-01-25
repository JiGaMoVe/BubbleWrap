using UnityEngine;
using UnityEngine.UI;

public interface IExplosion
{
    public void Explode();
    public void FailExplode();
}

[RequireComponent(typeof(Image))]
public class Explosion : MonoBehaviour, IExplosion
{
    private Image _image;
    private AlphaButton _button;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<AlphaButton>();
    }
    
    public void Explode()
    {
        _image.color = Color.blue;
        _button.Interactable = false;
    }

    public void FailExplode()
    {
        _image.color = Color.grey;
        _button.Interactable = false;
    }
}
