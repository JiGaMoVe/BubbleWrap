using System.Collections;
using System.Linq;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    [SerializeField] private EnergyBubble energyBubble;
    [SerializeField] private int correctToExplode;
    
    public bool ActiveStarMode { get; private set; }

    private void OnEnable()
    {
        energyBubble.onEnergyFull.AddListener(OnEnergyFull);
    }

    private void OnDisable()
    {
        energyBubble.onEnergyFull.RemoveListener(OnEnergyFull);
    }

    private void OnEnergyFull()
    {
        StartCoroutine(StartStarMode());
        FindObjectsByType<Bubble>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).ToList().ForEach(bubble =>
        {
            bubble.BubbleType = BubbleType.Special;
        });
    }

    private IEnumerator StartStarMode()
    {
        ActiveStarMode = true;
        yield return new WaitForSeconds(5);
        ActiveStarMode = false;
        StartCoroutine(WaitToSpecialEnd());
    }

    private IEnumerator WaitToSpecialEnd()
    {
        while (true)
        {
            if (FindObjectsByType<Bubble>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).Any(bubble => bubble.BubbleType is BubbleType.Special))
            {
                yield return new WaitForSeconds(0.5f);
                continue;
            }

            break;
        }
        
        MusicController.Instance.SwitchGlow();
    }

    public void AddEnergy()
    {
        if (ActiveStarMode) return;
        energyBubble.AddEnergy(1f / correctToExplode);
    }
}
