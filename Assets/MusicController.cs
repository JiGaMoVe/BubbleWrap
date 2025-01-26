using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController _instance;
    
    public static MusicController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<MusicController>();
            }
            return _instance;
        }
    }
    
    [SerializeField] private AudioSource source;
    [SerializeField] private List<AudioClip> musicClips;
    [SerializeField] private List<AudioClip> glowClip;
    
    private bool _isGlow;
    private int _index;
    
    public void NextSong()
    {
        var clips = _isGlow ? glowClip : musicClips;
        _index++;
        if (_index >= clips.Count) return;
        source.clip = clips[_index];
        source.Play();
    }

    public void SwitchGlow()
    {
        _isGlow = !_isGlow;
        var clips = _isGlow ? glowClip : musicClips;
        float time = source.time;
        source.clip = clips[_index];
        source.Play();
        source.time = time;
    }
}
