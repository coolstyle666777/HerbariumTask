using UnityEngine;

public class Cell : MonoBehaviour
{
    private Player _player;
    private Transform _selfTransform;
    public Utils.Directions Direction;
    public Cell Previous { get; set; }
    public Cell Next { get; set; }
    public bool PlayerOnCell { get; set; }
    public Player Player => _player;
    public Transform SelfTransform => _selfTransform;

    private void Awake()
    {
        _selfTransform = transform;
        _player = FindObjectOfType<Player>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up / 2, Utils.GetVectorByDirection(Direction));
    }
}
