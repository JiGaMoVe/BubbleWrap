using TMPro;
using UnityEngine;
using UnityEngine.Events;

public static class ScorePrefix
{
    private static string[] _superSuffix = { "K", "M", "G", "P", "A" };
    
    public static string AddPrefix(ulong value)
    {
        if (value < 1000)
        {
            return value.ToString();
        }
        
        int index = 0;
        double newValue = value;
        while (newValue >= 1000)
        {
            newValue /= 1000;
            index++;
        }

        return $"{newValue:0.##}{_superSuffix[index - 1]}";
    }
}

public class ScoreController : MonoBehaviour
{
    [SerializeField] private ComboController comboController;
    [SerializeField] private TMP_Text scoreText;
    
    private ulong _score;
    
    public UnityEvent<ulong> onScoreChange = new();

    public void AddScore()
    {
        _score += 1 * comboController.GetCombo();
        UpdateScore();
    }

    public void AddSpecialScore()
    {
        _score += 10 * comboController.GetCombo();
        UpdateScore();
    }

    public void RemoveScore()
    {
        if (_score <= comboController.GetCombo())
        {
            _score = 0;
            UpdateScore();
            return;
        }
        _score -= 1 * comboController.GetCombo();
        UpdateScore();
    }

    private void UpdateScore()
    {
        onScoreChange.Invoke(_score);
        scoreText.text = ScorePrefix.AddPrefix(_score);
    }
}
