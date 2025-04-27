using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public float speed;
    private void Update()
    {
        Vector3 newPos = target.transform.position + offset;
        Vector3 desiredPos = Vector3.MoveTowards(transform.position, newPos, speed);
        transform.position = desiredPos;    
    }
}