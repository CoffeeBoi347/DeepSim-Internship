using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Values")]

    public int kills;
    public float timeSurvived;
    public PlayerController playerController;

    [Header("Text Values")]

    public TMP_Text killsTxt;

    [Header("You Died")]

    public GameObject youDied;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void IncreaseKills()
    {
        kills += 1;
        killsTxt.text = "KILLS: " + kills.ToString();
    }

    private void Update()
    {
        timeSurvived += Time.deltaTime;
        if (playerController.hasCollidedWithEnemy)
        {
            var youDiedObj = youDied.GetComponent<CanvasGroup>().alpha = 1;
            Time.timeScale = 0f;
        }
    }
}