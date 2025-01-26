using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private float timePerFrame = 0.02f;
    [SerializeField] private bool autoStart;
    [SerializeField] private bool loop;
    
    private Image _image;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    
    private void Start()
    {
        if (autoStart)
        {
            StartCoroutine(Animate());
        }
    }
    
    public IEnumerator Animate()
    {
        while (true)
        {
            foreach (var sprite in sprites)
            {
                _image.sprite = sprite;
                yield return new WaitForSeconds(timePerFrame);
            }

            if (!loop) break;
            yield return null;
        }
    }

    public void Restart()
    {
        _image.sprite = sprites[0];
    }
}
