using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Text))]
public class SelectButton : MonoBehaviour
{
    [SerializeField] private SkinsPanel _skinsPanel;
    private Button _button;
    private Text _text;
    private const string SELECTED_TEXT = "Выбрано";
    private const string UNSELECTED_TEXT = "Выбрать";

    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        ChangeButtonState();
    }

    public void ChangeButtonState()
    {
        if (_skinsPanel.SelectedIndex == _skinsPanel.CurrentIndex)
        {
            _button.interactable = false;
            _text.text = SELECTED_TEXT;
        }
        else
        {
            _button.interactable = true;
            _text.text = UNSELECTED_TEXT;
        }
    }
}
