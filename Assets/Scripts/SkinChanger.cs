using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private GameObject _rightArm;
    [SerializeField] private GameObject _leftArm;
    private SkinsPanel _skinsPanel;
    private SkinnedMeshRenderer _render;

    private void Awake()
    {
        _render = GetComponentInChildren<SkinnedMeshRenderer>(true);
        _skinsPanel = FindObjectOfType<SkinsPanel>();
    }

    private void OnEnable()
    {
        if (_skinsPanel != null)
            _skinsPanel.skinChanged += ChangeSkin;
    }

    private void OnDisable()
    {
        if (_skinsPanel != null)
            _skinsPanel.skinChanged -= ChangeSkin;
    }

    private void Start()
    {
        if (GameData.CurrentSkin != null)
        {
            ChangeSkin(GameData.CurrentSkin);
        }
    }

    public void ChangeSkin(SkinsData skin)
    {
        GameObject newRightArm = Instantiate(skin.RightArm, _rightArm.transform.parent);
        Destroy(_rightArm);
        _rightArm = newRightArm;
        GameObject newLeftArm = Instantiate(skin.LeftArm, _leftArm.transform.parent);
        Destroy(_leftArm);
        _leftArm = newLeftArm;
        _render.material.SetTexture("_MainTex", skin.Texture);
    }
}
