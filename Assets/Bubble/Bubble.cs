using UnityEngine;

public class Bubble : MonoBehaviour
{
    private AlphaButton _button;
    private IExplosion _explosion;
    private IActive _active;

    private bool _isCorrect;
    
    public bool IsCorrect
    {
        get => _isCorrect;
        set
        {
            _isCorrect = value;
            if (_isCorrect)
            {
                _active .Activate();
            }
        }
    }

    private void Awake()
    {
        _button = GetComponent<AlphaButton>();
        _explosion = GetComponent<IExplosion>();
        _active = GetComponent<IActive>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if (IsCorrect)
        {
            _explosion.Explode();
        }
        else
        {
            _explosion.FailExplode();
        }
    }
}
