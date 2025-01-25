using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public interface ICalculateInCanvas
{
    bool Intersect();
}

public class CalculateInCanvasWithBounds : ICalculateInCanvas
{
    private readonly RectTransform _rectTransform;
    private readonly RectTransform _canvasRectTransform;
    
    public CalculateInCanvasWithBounds(Canvas canvas, RectTransform rectTransform)
    {
        _rectTransform = rectTransform;
        _canvasRectTransform = canvas.GetComponent<RectTransform>();
    }

    public bool Intersect()
    {
        var canvasCorners = new Vector3[4];
        _canvasRectTransform.GetWorldCorners(canvasCorners);
        var canvasBound = new Bounds(canvasCorners[0], Vector3.zero);
        for (int i = 1; i < 4; i++)
        {
            canvasBound.Encapsulate(canvasCorners[i]);
        }

        var rectCorners = new Vector3[4];
        _rectTransform.GetWorldCorners(rectCorners);
        var rectBound = new Bounds(rectCorners[0], Vector3.zero);
        for (int i = 1; i < 4; i++)
        {
            rectBound.Encapsulate(rectCorners[i]);
        }

        return canvasBound.Intersects(rectBound);
    }
}

public class DetectOutOfCanvas : MonoBehaviour
{
    private Canvas _canvas;
    private RectTransform _rectTransform;
    private ICalculateInCanvas _calculateInCanvas;
    
    public UnityEvent onEnterInCanvas = new();
    public UnityEvent onExitOfCanvas = new();
    
    private bool _isOutOfCanvas;
    private bool _onceInCanvas;
    private bool _onceOutOfCanvas;
    
    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        _calculateInCanvas = new CalculateInCanvasWithBounds(_canvas, _rectTransform);
    }

    private void Start()
    {
        StartCoroutine(StartLate());
    }
    
    private IEnumerator StartLate()
    {
        _isOutOfCanvas = !_calculateInCanvas.Intersect();
        StartCoroutine(WaitUpdate());
        yield return null;
    }

    private IEnumerator WaitUpdate()
    {
        while (true)
        {
            if (_calculateInCanvas.Intersect())
            {
                _onceOutOfCanvas = false;
                if (_isOutOfCanvas)
                {
                    if (!_onceInCanvas)
                    {
                        onEnterInCanvas?.Invoke();
                        _isOutOfCanvas = false;
                        _onceInCanvas = true;
                    }
                }
            }
            else
            {
                _onceInCanvas = false;
                if (!_isOutOfCanvas)
                {
                    if (!_onceOutOfCanvas)
                    {
                        onExitOfCanvas?.Invoke();
                        _isOutOfCanvas = true;
                        _onceOutOfCanvas = true;
                    }
                }
            }

            yield return null;
        }
    }
}
