using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private MoveWrap moveWrap;
    
    private Button _button;
    
    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnResume);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnResume);
    }
    
    private void OnResume()
    {
        pauseMenu.SetActive(false);
        moveWrap.Resume();
    }
}
