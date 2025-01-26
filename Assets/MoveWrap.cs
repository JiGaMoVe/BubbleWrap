using UnityEngine;

public class MoveWrap : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private RectTransform _rectTransform;
    private ScoreController _scoreController;

    private float _increment;

    private bool _pause;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void Pause()
    {
        _pause = true;
    }

    public void Resume()
    {
        _pause = false;
    }

    public void SpeedUp()
    {
        _increment++;
    }

    private void Update()
    {
        if (_pause) return;
        _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, _rectTransform.anchoredPosition.y - Time.deltaTime * (speed + _increment * 50));
    }
}
