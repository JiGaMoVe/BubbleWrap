using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SfxController : MonoBehaviour
{
    private static SfxController _instance;
    public static SfxController Instance => _instance ??= FindAnyObjectByType<SfxController>();
    
    [SerializeField] private List<AudioClip> plasticBubblePop;
    [SerializeField] private AudioClip failPlasticBubblePop;
    [SerializeField] private AudioClip bubblePop;
    
    
    private AudioSource _audioSource;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayPlasticBubblePop()
    {
        _audioSource.PlayOneShot(plasticBubblePop[Random.Range(0, plasticBubblePop.Count)]);
    }
    
    public void PlayFailPlasticBubblePop()
    {
        _audioSource.PlayOneShot(failPlasticBubblePop);
    }
    
    public void PlayBubblePop()
    {
        _audioSource.PlayOneShot(bubblePop);
    }
}
