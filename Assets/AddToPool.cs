using UnityEngine;

public class AddToPool : MonoBehaviour
{
    [SerializeField] private Line linePrefab;

    public void Add()
    {
        var line = Instantiate(linePrefab, transform);
        line.transform.SetAsFirstSibling();
        // var space = new GameObject
        // {
        //     name = "Space",
        //     transform = { parent = transform }
        // };
        // var spaceRectTransform = space.AddComponent<RectTransform>();
        // spaceRectTransform.sizeDelta = new Vector2(0, ((RectTransform)line.transform).sizeDelta.y);
    }
}
