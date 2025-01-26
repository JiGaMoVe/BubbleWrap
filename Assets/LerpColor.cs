using UnityEngine;
using UnityEngine.UI;

public class LerpColor : MonoBehaviour
{
    [SerializeField] private Color firstColor;
    [SerializeField] private Color secondColor;
    
    private Image _renderer;
    
    private void Awake()
    {
        _renderer = GetComponent<Image>();
    }
    
    private void Update()
    {
        var color = Color.Lerp(firstColor, secondColor, Mathf.PingPong(Time.time, 1));
        _renderer.color = color;
    }
}
