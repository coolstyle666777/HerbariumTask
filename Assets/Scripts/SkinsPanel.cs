using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class SkinsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private SkinsData[] _skins;
    private CanvasGroup _canvasGroup;
    private int _currentIndex;
    private int _selectedIndex;

    public int SelectedIndex => _selectedIndex;
    public int CurrentIndex => _currentIndex;

    public UnityAction<SkinsData> skinChanged;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        for (int i = 0; i < _skins.Length; i++)
        {
            if (_skins[i] == GameData.CurrentSkin)
            {
                _selectedIndex = i;
            }
        }
        skinChanged?.Invoke(_skins[_currentIndex]);
    }

    private void ChangeCurrentIndex(bool isNext)
    {
        if (isNext)
        {
            if (_currentIndex != _skins.Length - 1)
                _currentIndex++;
            else
                _currentIndex = 0;
        }
        else
        {
            if (_currentIndex != 0)
                _currentIndex--;
            else
                _currentIndex = _skins.Length - 1;
        }
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

    public void OnChangeSkinButtonClick(bool isNext)
    {
        ChangeCurrentIndex(isNext);
        skinChanged?.Invoke(_skins[_currentIndex]);
    }

    public void OnSelectButtonClick()
    {
        _selectedIndex = _currentIndex;
        GameData.CurrentSkin = _skins[_selectedIndex];
    }
}
