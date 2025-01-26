using System.Collections.Generic;
using UnityEngine;

public class SpecialBubble : MonoBehaviour, ISpecial
{
    [SerializeField] private List<GameObject> views;

    private void Awake()
    {
        foreach (var view in views)
        {
            view.SetActive(false);
        }
    }

    public void Activate()
    {
        foreach (var view in views)
        {
            view.SetActive(true);
        }
    }

    public void Deactivate()
    {
        foreach (var view in views)
        {
            view.SetActive(false);
        }
    }
}
