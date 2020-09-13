using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class PanelLose : MonoBehaviour
{
    [SerializeField] private Player _player;
    private CanvasGroup _canvasGroup;


    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _player.Dead += ShowPanel;
    }

    private void OnDisable()
    {
        _player.Dead -= ShowPanel;
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowPanel()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }
}
