using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ComboController : MonoBehaviour
{
    [SerializeField] private TMP_Text comboText;
    
    public UnityEvent<ulong> onComboChange = new();
    
    private ulong _combo;

    public ulong GetCombo()
    {
        return _combo;
    }

    public void IncrementCombo()
    {
        _combo++;
        onComboChange.Invoke(_combo);
        comboText.text = ScorePrefix.AddPrefix(GetCombo());
    }
}
