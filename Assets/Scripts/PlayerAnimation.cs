using UnityEngine;

[RequireComponent(typeof(Animator),typeof(Player),typeof(PlayerMover))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Player _player;
    private PlayerMover _playerMover;
    private const string DEATH_TRIGGER = "Death";
    private const string MOVE_TRIGGER = "Move";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _player.Dead += OnDead;
        _playerMover.Moved += OnMoved;
    }

    private void OnDisable()
    {
        _player.Dead -= OnDead;
        _playerMover.Moved -= OnMoved;
    }

    private void OnDead()
    {
        _animator.SetTrigger(DEATH_TRIGGER);
    }

    public void OnMoved()
    {
        _animator.SetTrigger(MOVE_TRIGGER);
    }
}
