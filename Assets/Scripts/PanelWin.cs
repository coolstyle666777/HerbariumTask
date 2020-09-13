using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PanelWin : MonoBehaviour
{
    [SerializeField] private Player _player;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _player.Win += ShowPanel;
    }

    private void OnDisable()
    {
        _player.Win -= ShowPanel;
    }

    public void ShowPanel()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }
}
