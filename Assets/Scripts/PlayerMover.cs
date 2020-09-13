using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8;
    private Player _player;
    private Cell _currentCell;
    private StartCell _startCell;
    private Vector3 _nextPosition;
    private Transform _selfTransform;

    public UnityAction Moved;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _startCell = FindObjectOfType<StartCell>();
        _currentCell = _startCell.GetComponent<Cell>();
        _selfTransform = transform;
    }

    private void Start()
    {
        _nextPosition = new Vector3(_currentCell.SelfTransform.position.x, _selfTransform.position.y, _currentCell.SelfTransform.position.z);
    }
  
    private void MoveNextCell()
    {
        if (_currentCell.Next != null)
        {
            _nextPosition = new Vector3(_currentCell.Next.SelfTransform.position.x, _selfTransform.position.y, _currentCell.Next.SelfTransform.position.z);
            _currentCell.Next.PlayerOnCell = true;
            _currentCell.PlayerOnCell = false;
            RotateToDirection(Utils.GetVectorByDirection(_currentCell.Next.Direction));
            _currentCell = _currentCell.Next;         
        }
    }

    private void MovePreviousCell()
    {
        if (_currentCell.Previous != null)
        {
            _nextPosition = new Vector3(_currentCell.Previous.SelfTransform.position.x, _selfTransform.position.y, _currentCell.Previous.SelfTransform.position.z);
            _currentCell.Previous.PlayerOnCell = true;
            _currentCell.PlayerOnCell = false;
            RotateToDirection(Utils.GetVectorByDirection(_currentCell.Previous.Direction) * -1);
            _currentCell = _currentCell.Previous;
        }
    }

    private void RotateToDirection(Vector3 direction)
    {
        _selfTransform.LookAt(_selfTransform.position + direction);
    }

    private void CheckWinCondition()
    {
        if (_currentCell.TryGetComponent(out ChestCell chest))
        {
            _player.CompleteLevel();
        }
    }

    private void FixedUpdate()
    {
        _selfTransform.position = Vector3.MoveTowards(_selfTransform.position, _nextPosition, _moveSpeed * Time.fixedDeltaTime);
    }

    public void MovePlayerToCell(bool IsNext)
    {
        if (IsNext)
        {
            MoveNextCell();
        }
        else
        {
            MovePreviousCell();
        }
        Moved?.Invoke();
        CheckWinCondition();
    }
}
