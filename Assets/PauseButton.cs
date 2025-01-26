using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private MoveWrap moveWrap;
    

    private void OnEnable()
    {
        button.onClick.AddListener(OnPause);
    }
    
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnPause);
    }
    
    private void OnPause()
    {
        pausePanel.SetActive(true);
        moveWrap.Pause();
    }
}
