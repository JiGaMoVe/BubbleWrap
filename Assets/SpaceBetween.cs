using UnityEngine;
using UnityEngine.UI;

public class SpaceBetween : MonoBehaviour
{
    [SerializeField] private float spacing = 1f;
    
    private void OnValidate()
    {
        var horizontalLayouts = GetComponentsInChildren<HorizontalLayoutGroup>();
        var verticalLayouts = GetComponentsInChildren<VerticalLayoutGroup>();
        
        foreach (var layout in horizontalLayouts)
        {
            layout.spacing = spacing;
        }
        
        foreach (var layout in verticalLayouts)
        {
            layout.spacing = spacing;
        }
    }
}
