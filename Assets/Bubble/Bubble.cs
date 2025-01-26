using System;
using UnityEngine;

public enum BubbleType
{
    Correct,
    Special,
    Incorrect
}

public class Bubble : MonoBehaviour
{
    private AlphaButton _button;
    private IExplosion _explosion;
    private IActive _active;
    private ISpecial _special;
    
    private EnergyController _energyController;
    private ComboController _comboController;
    private ScoreController _scoreController;
    
    private BubbleType _bubbleType = BubbleType.Incorrect;
    
    public BubbleType BubbleType
    {
        get => _bubbleType;
        set
        {
            _bubbleType = value;
            switch (_bubbleType)
            {
                case BubbleType.Correct:
                    if (IsExploded) return;
                    _active.Activate();
                    break;
                case BubbleType.Special:
                    if (IsExploded) return;
                    _special.Activate();
                    break;
                case BubbleType.Incorrect:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public bool IsExploded { get; private set; }

    private void Awake()
    {
        _button = GetComponentInChildren<AlphaButton>();
        _explosion = GetComponentInChildren<IExplosion>();
        _active = GetComponent<IActive>();
        _special = GetComponent<ISpecial>();
        _energyController = FindAnyObjectByType<EnergyController>();
        _comboController = FindAnyObjectByType<ComboController>();
        _scoreController = FindAnyObjectByType<ScoreController>();
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
        IsExploded = true;
        _active.Deactivate();
        _special.Deactivate();
        
        switch (_bubbleType)
        {
            case BubbleType.Correct:
                _explosion.Explode();
                _comboController.IncrementCombo();
                _scoreController.AddScore();
                _energyController.AddEnergy();
                SfxController.Instance.PlayPlasticBubblePop();
                break;
            case BubbleType.Special:
                _explosion.Explode();
                _comboController.IncrementCombo();
                _scoreController.AddSpecialScore();
                SfxController.Instance.PlayPlasticBubblePop();
                break;
            case BubbleType.Incorrect:
                _scoreController.RemoveScore();
                _explosion.FailExplode();
                SfxController.Instance.PlayFailPlasticBubblePop();
                break;
            default: 
                throw new ArgumentOutOfRangeException();
        }
    }
}
