using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float velocity;

    private void Start()
    {
        velocity *= -1;
    }
    private void Update()
    {
        transform.Translate(0f, 0f, velocity);
        Destroy(gameObject, 3f);
    }
}