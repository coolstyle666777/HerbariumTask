using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelEditorWindow : EditorWindow
{
    private List<GameObject> _listOfCells;
    private Dictionary<int, string> _directionDictionary = new Dictionary<int, string>
    {
        {0, "forward"},
        {1, "right"},
        {2, "back"},
        {3, "left"}
    };

    private int _selectionCellId = 0;
    private int _selectionDirectionId = 0;
    private Utils.Directions _selectDirection;

    [MenuItem("Window/LevelEditor")]
    public static void ShowWindow()
    {
        GetWindow<LevelEditorWindow>("LevelEditor");
    }

    private void Awake()
    {
        if (_listOfCells == null)
        {
            _listOfCells = GetCellPrefabs();
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginVertical("Box");
        GUILayout.Label("Select prefab");
        FillSelectionGrid();
        GUILayout.EndVertical();
        GUILayout.Label("Select Direction");
        GUILayout.BeginVertical("Box");
        FillDirectionGrid();
        GUILayout.EndVertical();
        if (GUILayout.Button("spawn"))
        {
            if (Selection.activeGameObject != null)
            {
                if (Selection.activeGameObject.TryGetComponent(out Cell targetCell))
                {
                    Vector3 newCellposition = new Vector3();
                    Transform targetTransform = targetCell.transform;
                    newCellposition = targetTransform.position + Utils.GetVectorByDirection((Utils.Directions)_selectionDirectionId);
                    targetCell.Direction = (Utils.Directions)_selectionDirectionId;
                    GameObject cell = Instantiate(_listOfCells[_selectionCellId], newCellposition, targetTransform.rotation);
                    cell.transform.SetParent(targetTransform.parent);
                    Selection.activeGameObject = cell;
                }
            }
            else
            {
                ShowNotification(new GUIContent("Select a cell on the scene"));
            }
        }
    }

    private void FillSelectionGrid()
    {
        string[] cellNames = new string[_listOfCells.Count];
        for (int i = 0; i < _listOfCells.Count; i++)
        {
            cellNames[i] = _listOfCells[i].name;
        }
        _selectionCellId = GUILayout.SelectionGrid(_selectionCellId, cellNames, 2);
    }

    private void FillDirectionGrid()
    {
        string[] directionNames = new string[4];
        for (int i = 0; i < _directionDictionary.Count; i++)
        {
            directionNames[i] = _directionDictionary[i];
        }
        _selectionDirectionId = GUILayout.SelectionGrid(_selectionDirectionId, directionNames, 4);
    }

    private List<GameObject> GetCellPrefabs()
    {
        string[] search_results = System.IO.Directory.GetFiles("Assets/Prefabs/Cells/", "*.prefab", System.IO.SearchOption.AllDirectories);
        List<GameObject> cellPrefabs = new List<GameObject>();
        for (int i = 0; i < search_results.Length; i++)
        {
            GameObject prefab = null;
            prefab = (GameObject)AssetDatabase.LoadMainAssetAtPath(search_results[i]);
            cellPrefabs.Add(prefab);
        }
        return cellPrefabs;
    }
}
