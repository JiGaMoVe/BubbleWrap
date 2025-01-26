using System.Collections;
using System.Linq;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    [SerializeField] private EnergyBubble energyBubble;
    [SerializeField] private int correctToExplode;
    
    public bool ActiveStarMode { get; set; }

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
    }

    public void AddEnergy()
    {
        if (ActiveStarMode) return;
        energyBubble.AddEnergy(1f / correctToExplode);
    }
}
