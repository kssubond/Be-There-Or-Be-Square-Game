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
    public float screenOffset = 0.5f;

    private GameObject[] pipes;
    private int currentPipe = 0;

    private Vector2 objectPoolPosition = new Vector2 (-15, -25);

    private float timeSinceLastSpawned;

    [SerializeField]private new Camera camera;

    void Awake()
    {
        
    }
    void Start()
    {
        camera = GetComponent<Camera>();

        timeSinceLastSpawned = 0;
        pipes = new GameObject[pipePoolSize];

        for (int i = 0; i < pipePoolSize; i++)
        {
            pipes[i] = Instantiate(pipePrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        camera = Camera.main;
        Vector3 bottomLeftWorld = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 topRightWorld = camera.ScreenToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        timeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;
            float spawnYPosition = Random.Range(pipeMin, pipeMax);
            pipes[currentPipe].transform.position = new Vector3(Random.Range(-bottomLeftWorld.x, -topRightWorld.x) + screenOffset, spawnYPosition, 0);
            currentPipe++;

            if(currentPipe >= pipePoolSize)
            {
                currentPipe = 0;
            }
        }
    }
}
