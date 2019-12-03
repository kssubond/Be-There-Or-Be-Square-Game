using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public GameObject pipePrefab;
    public int pipePoolSize = 5;
    public float spawnRate = 3f;
    public float pipeMin = -1f;
    public float pipeMax = 3.5f;

    private GameObject[] pipes;
    private int currentPipe = 0;

    private Vector2 objectPoolPosition = new Vector2 (-15, -25);

    private float spawnXPosition = 4f;
    private float timeSinceLastSpawned;

    void Start()
    {
        timeSinceLastSpawned = 0;
        pipes = new GameObject[pipePoolSize];
        for (int i = 0; i < pipePoolSize; i++)
        {
            pipes[i] = (GameObject)Instantiate(pipePrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;
            float spawnYPosition = Random.Range(pipeMin, pipeMax);
            pipes[currentPipe].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentPipe++;

            if(currentPipe >= pipePoolSize)
            {
                currentPipe = 0;
            }
        }
    }
}
