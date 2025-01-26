using UnityEngine;

public class MoveWrap : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private RectTransform _rectTransform;
    private ScoreController _scoreController;

    private float _increment;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SpeedUp()
    {
        _increment++;
    }

    private void Update()
    {
        _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, _rectTransform.anchoredPosition.y - Time.deltaTime * (speed + _increment * 50));
    }
}
