using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    private DetectOutOfCanvas _detectOutOfCanvas;
    private AddToPool _addToPool;
    
    public List<Bubble> Bubbles { get; private set; } = new();

    private void Awake()
    {
        Bubbles = GetComponentsInChildren<Bubble>().ToList();
        _addToPool = GetComponentInParent<AddToPool>();
    }

    private void OnEnable()
    {
        if (_detectOutOfCanvas == null) _detectOutOfCanvas = GetComponent<DetectOutOfCanvas>();
        _detectOutOfCanvas.onExitOfCanvas.AddListener(OnExitOfCanvas);
    }
    
    private void OnDisable()
    {
        _detectOutOfCanvas.onExitOfCanvas.RemoveListener(OnExitOfCanvas);
    }
    
    private void OnExitOfCanvas()
    {
        if (transform.GetSiblingIndex() != transform.parent.childCount - 1) return;
        _addToPool.Add();
        var parent = (RectTransform) transform.parent;
        parent.anchoredPosition = new Vector2(parent.anchoredPosition.x, parent.anchoredPosition.y + 200);
        Destroy(gameObject);
    }
}