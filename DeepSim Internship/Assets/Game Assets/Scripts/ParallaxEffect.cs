using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float start, length;
    public float parallaxFactor;
    public Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
        start = transform.position.z;
        length = GetComponent<SpriteRenderer>().bounds.size.z;
    }

    private void Update()
    {
        float parallaxEffect = mainCam.transform.position.z * parallaxFactor;
        transform.position = new Vector3(transform.position.x, transform.position.y, start + parallaxEffect);
    }
}