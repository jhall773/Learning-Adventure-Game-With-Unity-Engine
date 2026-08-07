using NUnit.Framework.Constraints;
using UnityEngine;

public class CircleMover : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Units per second

    // Called by UI Button "UP"
    public void MoveUp()
    {
        Vector3 oldPos = transform.position;

        transform.Translate(Vector3.up * moveSpeed, Space.World);
        
        if(transform.position.y >= 4.45)
        {
            Vector3 newPosition = new Vector3(transform.position.x, 4.45f, transform.position.z);
            Quaternion oldRotation = new Quaternion();
            Vector3 oldPosition = new Vector3(); //This variable is discarded, but needed in the 'GetPositionAndRotation()' function.
            transform.GetPositionAndRotation(out oldPosition, out oldRotation);
            transform.SetPositionAndRotation(newPosition,oldRotation);
        }
        
        Debug.Log($"Button MoveUp: Delta {(transform.position - oldPos)}, NewPos {transform.position}");
    }


    // Called by UI Button "DOWN"
    public void MoveDown()
    {
        Vector3 oldPos = transform.position;

        transform.Translate(Vector3.down * moveSpeed, Space.World);
        if(transform.position.y <= -0.7)
        {
            Vector3 newPosition = new Vector3(transform.position.x, -0.7f, transform.position.z);
            Quaternion oldRotation = new Quaternion();
            Vector3 oldPosition = new Vector3(); //This variable is discarded, but needed in the 'GetPositionAndRotation()' function.
            transform.GetPositionAndRotation(out oldPosition, out oldRotation);
            transform.SetPositionAndRotation(newPosition,oldRotation);
        }

        Debug.Log($"Button MoveDown: Delta {(transform.position - oldPos)}, NewPos {transform.position}");
    }
}
