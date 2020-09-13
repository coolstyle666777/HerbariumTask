using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Cell), typeof(Animation))]
public class TrapCell : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _activeDuration;
    [SerializeField] private float _reloadInterval;
    private Player _player;
    private Cell _currentCell;
    private Animation _animation;
    private bool _isActive;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _currentCell = GetComponent<Cell>();
        _animation = GetComponentInChildren<Animation>();
    }

    private void Start()
    {
        StartCoroutine(Delay(_delay));
    }

    private IEnumerator Delay(float duration)
    {
        yield return new WaitForSeconds(duration); 
        _animation.Play();
        StartCoroutine(ActivateTrap(_activeDuration, _reloadInterval));
    }

    private IEnumerator ActivateTrap(float duration, float interval)
    {
        WaitForSeconds waitForInterval = new WaitForSeconds(interval);
        while (true)
        {
            float currentDuration = duration;
            while (currentDuration > 0)
            {
                _isActive = true;
                currentDuration -= Time.deltaTime;
                if (_currentCell.PlayerOnCell)
                    _player.Death();
                yield return null;
            }
            _isActive = false;
            yield return waitForInterval; 
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (_isActive)
            Gizmos.DrawCube(_currentCell.SelfTransform.position, Vector3.one);
    }
}
