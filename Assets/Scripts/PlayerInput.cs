using UnityEngine;

[RequireComponent(typeof(Player), typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private Player _player;
    private PlayerMover _playerMover;
    private bool _canMove = true;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Dead += OnDead;
    }

    private void OnDisable()
    {
        _player.Dead -= OnDead;
    }

    private void Update()
    {
        CheckTouch();
    }

    private void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (_canMove)
                    {
                        _playerMover.MovePlayerToCell(IsRightTouch(touch));
                        _canMove = false;
                    }
                    break;
                case TouchPhase.Ended:
                    _canMove = true;
                    break;
            }
        }
    }

    private bool IsRightTouch(Touch touch)
    {
        return touch.position.x > Screen.width / 2;
    }

    private void OnDead()
    {
        enabled = false;
    }
}
