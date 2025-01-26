using System.Linq;
using UnityEngine;

public class SelectCorrectBubbles : MonoBehaviour
{
    private Line _line;
    
    private void Awake() => _line = GetComponent<Line>();

    private void Start()
    {
        if (!_line.Bubbles.Any()) return;

        if (FindAnyObjectByType<EnergyController>().ActiveStarMode)
        {
            foreach (var bubble in _line.Bubbles)
            {
                bubble.BubbleType = BubbleType.Special;
            }
            return;
        }
        
        int correctQuantity = Random.Range(MinCorrectQuantity(), MaxCorrectQuantity() + 1);
        
        for (int i = 0; i < correctQuantity; i++)
        {
            while (true)
            {
                if (_line.Bubbles.All(bubble => bubble.BubbleType is BubbleType.Correct)) break;
                var bubble = _line.Bubbles[Random.Range(0, _line.Bubbles.Count)];
                if (bubble.BubbleType is BubbleType.Correct) continue;
                bubble.BubbleType = BubbleType.Correct;
                break;
            }
            
        }
    }

    private int MinCorrectQuantity()
    {
        return _line.Bubbles.Count <= 0 ? 0 : 1;
    }

    private int MaxCorrectQuantity()
    {
        return _line.Bubbles.Count switch
        {
            <= 0 => 1,
            < 5 => _line.Bubbles.Count,
            _ => _line.Bubbles.Count - 2
        };
    }
}
