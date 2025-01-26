using UnityEngine;

public class PhaseCalculation : MonoBehaviour
{
    private MoveWrap _moveWrap;
    private ComboController _comboController;

    private int _phase;

    private void Awake()
    {
        _moveWrap = GetComponent<MoveWrap>();
    }

    private void OnEnable()
    {
        if(_comboController == null) _comboController = FindAnyObjectByType<ComboController>();
        _comboController.onComboChange.AddListener(OnComboChange);
    }
    
    private void OnDisable()
    {
        _comboController.onComboChange.RemoveListener(OnComboChange);
    }
    
    private void OnComboChange(ulong value)
    {
        int currentValue = (int)Mathf.Floor(value / 100f);
        if (currentValue == _phase) return;
        _phase = currentValue;
        _moveWrap.SpeedUp();
        
        if (_phase % 2 == 0)
        {
            MusicController.Instance.NextSong();
        }
    }
}
