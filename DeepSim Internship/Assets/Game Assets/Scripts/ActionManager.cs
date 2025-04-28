using System.Collections;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    [Header("Screen Pause Settings")]

    public float screenPauseTime;

    [Header("Screen Shake Settings")]

    public float magnitude;
    public float timeToShake;
    public float currentTimer;

    public void ApplyEffects()
    {
        StartCoroutine(PauseScreen(0.1f));
        StartCoroutine(ShakeScreen(timeToShake));
    }

    private IEnumerator PauseScreen(float time)
    {
        Time.timeScale = screenPauseTime;
        yield return new WaitForSeconds(time);
        Time.timeScale = 1f;
    }

    private IEnumerator ShakeScreen(float time)
    {
        Vector3 originalPos = Camera.main.transform.position;
        currentTimer += Time.unscaledDeltaTime;
        while(timeToShake > currentTimer)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            Camera.main.transform.localPosition = new Vector3(x, y, Camera.main.transform.position.z);
            yield return null;
        }
        Camera.main.transform.position = originalPos;
    }
}