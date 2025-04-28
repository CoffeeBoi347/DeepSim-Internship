using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float velocity;

    private void Update()
    {
        transform.Translate(0f, 0f, velocity * -1);
    }
}