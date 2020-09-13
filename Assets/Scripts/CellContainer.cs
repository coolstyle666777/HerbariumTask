using UnityEngine;

public class CellContainer : MonoBehaviour
{
    private Cell[] _cells;

    private void Start()
    {
        _cells = FindObjectsOfType<Cell>();
        SetStartCell();
        InitializeCells();
    }

    private void SetStartCell()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (_cells[i].TryGetComponent(out StartCell start))
            {
                Cell temp = _cells[0];
                _cells[0] = _cells[i];
                _cells[i] = temp;
            }
        }
    }

    private void InitializeCells()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            for (int j = 1; j < _cells.Length; j++)
            {
                if (_cells[i].SelfTransform.position - _cells[j].SelfTransform.position == Utils.GetVectorByDirection(_cells[i].Direction) * -1)
                {
                    _cells[i].Next = _cells[j];
                    _cells[j].Previous = _cells[i];
                }
            }
        }
    }
}
