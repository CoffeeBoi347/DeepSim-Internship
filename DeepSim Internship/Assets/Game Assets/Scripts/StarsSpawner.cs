using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    public PlayerController playerController;
    public List<GameObject> stars = new List<GameObject>();
    public Transform starsSpawnerObj;
    public float destroyTime;
    public float timeLimit;
    public float currentTimer = 0f;
    public bool allowedToSpawn = false;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        allowedToSpawn = false;
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;
        if(currentTimer >= timeLimit && !allowedToSpawn && playerController.isMoving)
        {
            SpawnStarObj();
            allowedToSpawn = true;
            currentTimer = 0f;
        }
    }

    void SpawnStarObj()
    {
        int randomNum = Random.Range(0, stars.Count);
        GameObject objToSpawn = stars[randomNum];
        GameObject objSpawned = Instantiate(objToSpawn, starsSpawnerObj.position, Quaternion.identity);
        StartCoroutine(SetAllowToSpawnToFalse(0.1f));
        Destroy(objSpawned, destroyTime);
    }

    private IEnumerator SetAllowToSpawnToFalse(float time)
    {
        yield return new WaitForSeconds(time);
        allowedToSpawn = false;
    }
}