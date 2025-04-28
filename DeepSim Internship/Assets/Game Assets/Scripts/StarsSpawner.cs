using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    public PlayerController playerController;
    public TypeClass typeClass;
    public List<GameObject> stars = new List<GameObject>();
    public Transform starsSpawnerObj;
    public float destroyTime;
    public float timeLimit;
    public float currentTimer = 0f;
    public bool allowedToSpawn = false;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        typeClass = FindObjectOfType<TypeClass>();
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
        if (typeClass.typeClassVal == classType.Obstacle)
        {
            Destroy(objSpawned, destroyTime);
        }
        else
        {
            Debug.Log("Dont kill!");
        }
    }

    private IEnumerator SetAllowToSpawnToFalse(float time)
    {
        yield return new WaitForSeconds(time);
        allowedToSpawn = false;
    }
}