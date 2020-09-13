using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction Dead;
    public UnityAction Win;

    public void Death()
    {
        Dead?.Invoke();
    }

    public void CompleteLevel()
    {
        Win?.Invoke();
    }
}
