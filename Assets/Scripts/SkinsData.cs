using UnityEngine;

[CreateAssetMenu(fileName = "New SkinData", menuName = "Skin", order = 51)]
[SerializeField]
public class SkinsData : ScriptableObject
{
    public string Name;
    public Texture Texture;
    public GameObject RightArm;
    public GameObject LeftArm;
}
