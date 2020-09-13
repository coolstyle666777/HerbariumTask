using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class MainPanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private const int GAME_SCENE_BUILD_INDEX = 1;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(GAME_SCENE_BUILD_INDEX);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void ShowPanel()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }

    public void HidePanel()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }
}
