using UnityEngine;
using UnityEngine.UI;

public interface IExplosion
{
    public void Explode();
    public void FailExplode();
}

public class Explosion : MonoBehaviour, IExplosion
{
    [SerializeField] private Sprite explodeSprite;
    [SerializeField] private Follower explosionPrefab;
    [SerializeField] private Follower failExplosionPrefab;
    [SerializeField] private Color failExplosionColor;
    
    private AlphaButton _button;
    private Image _image;
    private Canvas _canvas;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<AlphaButton>();
        _canvas = GetComponentInParent<Canvas>();
    }
    
    public void Explode()
    {
        var follower = Instantiate(explosionPrefab, transform.position, Quaternion.identity, _canvas.transform);
        follower.Target = transform;
        _image.sprite = explodeSprite;
        _button.Interactable = false;
        Destroy(follower.gameObject, 2f);
    }

    public void FailExplode()
    {
        var follower = Instantiate(failExplosionPrefab, transform.position, Quaternion.identity, _canvas.transform);
        follower.Target = transform;
        _image.color = failExplosionColor;
        _button.Interactable = false;
        Destroy(follower.gameObject, 2f);
    }
}
