using System.Collections;
using TMPro;
using Unity.VisualScripting;
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

    [Header("Booleans")]

    public bool canIncreaseKill = true;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void IncreaseKills()
    {
        kills += 1;
        killsTxt.text = "SCORE: " + kills.ToString();
        canIncreaseKill = false;
        StartCoroutine(SetCanIncreaseKillToTrue(0.05f));
    }

    private void Update()
    {
        timeSurvived += Time.deltaTime;
        if (playerController.hasCollidedWithEnemy)
        {
            var youDiedObj = youDied.GetComponent<CanvasGroup>();
            youDiedObj.alpha = 1;
            youDiedObj.interactable = true;
            youDiedObj.blocksRaycasts = true;
            Time.timeScale = 0f;
        }
    }

    private IEnumerator SetCanIncreaseKillToTrue(float time)
    {
        yield return new WaitForSeconds(time);
        canIncreaseKill = true;
    }
}