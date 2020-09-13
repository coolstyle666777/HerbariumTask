using UnityEngine;

public class Utils : MonoBehaviour
{
    public enum Directions
    {
        Forward = 0,
        Right = 1,
        Back = 2,
        Left = 3
    }

    public static Vector3 GetVectorByDirection(Directions direction)
    {
        switch (direction)
        {
            case Directions.Forward:
                return Vector3.forward;
            case Directions.Right:
                return Vector3.right;
            case Directions.Back:
                return Vector3.back;
            case Directions.Left:
                return Vector3.left;
        }
        return Vector3.zero;
    }    
}
