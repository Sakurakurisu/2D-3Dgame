using UnityEngine;

public class BoxVisualizer : MonoBehaviour
{
    public LayerMask groundLayer;
    public Vector3 boxHalfExtents = new Vector3(0.4f, 0.4f, 0.4f);

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
 
        Vector3 boxPosition = transform.position; 
        Gizmos.DrawWireCube(boxPosition, boxHalfExtents * 2); 
    }
}
