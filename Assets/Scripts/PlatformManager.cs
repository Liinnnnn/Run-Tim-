using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public Transform[] obtacleSpawnPoint;
    public GameObject[] obtaclePrefab;
    // Update is called once per frame
    void Start()
    {
        SpawnObstacle();
        GameManager.onGameLost += lostGame;
    }
    void Update()
    {
        gameObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy"))
        {
            Destroy(gameObject, 4f);
        }
    }
    void SpawnObstacle()
    {
        int numberOfObstacles = Random.Range(1, 4);
        Debug.Log("Spawning " + numberOfObstacles + " obstacles.");

        List<int> availableIndices = new List<int>();
        for (int i = 0; i < obtacleSpawnPoint.Length - 1; i++)
        {
            availableIndices.Add(i);
        }

        for (int i = 0; i < numberOfObstacles; i++)
        {
            if (availableIndices.Count == 0) break;

            int randomIndexInList = Random.Range(0, availableIndices.Count);
            int spawnPointIndex = availableIndices[randomIndexInList];

            int randomObstacleIndex = Random.Range(0, obtaclePrefab.Length);

            GameObject obstacle = Instantiate(
                obtaclePrefab[randomObstacleIndex], 
                obtacleSpawnPoint[spawnPointIndex].position, 
                obtaclePrefab[randomObstacleIndex].transform.rotation
            );

            obstacle.transform.SetParent(gameObject.transform);

            availableIndices.RemoveAt(randomIndexInList);
        }
    }
    private void lostGame()
    {
        speed = 0;
    }   
}
