using UnityEngine;
using UnityEngine.UI;

public class SkinName : MonoBehaviour
{
    private Text _skinName;
    private SkinsPanel _skinsPanel;

    private void Awake()
    {
        _skinName = GetComponent<Text>();
        _skinsPanel = FindObjectOfType<SkinsPanel>();
    }

    private void OnEnable()
    {
        if (_skinsPanel != null)
            _skinsPanel.skinChanged += OnSkinChanged;
    }

    private void OnDisable()
    {
        if (_skinsPanel != null)
            _skinsPanel.skinChanged -= OnSkinChanged;
    }

    private void OnSkinChanged(SkinsData skin)
    {
        _skinName.text = skin.Name;
    }
}
