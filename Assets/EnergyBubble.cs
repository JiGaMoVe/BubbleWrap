using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnergyBubble : MonoBehaviour
{
    [SerializeField] private RectTransform bubbleTransform;
    [SerializeField] private Image bubbleImage;

    public UnityEvent onEnergyFull = new();
    
    private float _current;
    private UIAnimation _animation;

    private void OnEnable()
    {
        onEnergyFull.AddListener(OnEnergyFull);
        _animation = GetComponentInChildren<UIAnimation>();
    }

    private void OnDisable()
    {
        onEnergyFull.RemoveListener(OnEnergyFull);
    }

    private void OnEnergyFull()
    {
        StartCoroutine(OnEnergyFullCoroutine());
    }
    
    private IEnumerator OnEnergyFullCoroutine()
    {
        yield return StartCoroutine(_animation.Animate());
        bubbleImage.color = Color.clear;

        float value = 1f;
        
        while (true)
        {
            value -= Time.deltaTime * 2;
            SetSize(value);
            if (value <= 0)
            {
                _current = 0;
                SetSize(_current);
                break;
            }

            yield return null;
        }
        
        bubbleImage.color = Color.white;
        _animation.Restart();
    }

    public void AddEnergy(float energy)
    {
        if (_current >= 1) return;
        _current += energy;
        SetSize(_current);
        if (_current >= 1)
        {
            onEnergyFull.Invoke();
        }
    }
    
    public void RemoveEnergy(float energy)
    {
        if (_current <= 0) return;
        _current -= energy;
        SetSize(_current);
    }

    private void SetSize(float size)
    {
        bubbleTransform.sizeDelta = new Vector2(500 + size * 800, 500 + size * 800);
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) AddEnergy(0.05f);
        else if (Input.GetKeyDown(KeyCode.D)) RemoveEnergy(0.05f);
    }
#endif
}
