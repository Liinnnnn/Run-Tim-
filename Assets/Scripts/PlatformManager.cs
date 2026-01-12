using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public Transform[] obtacleSpawnPoint;
    public GameObject obtaclePrefab;

    // Update is called once per frame
    void Start()
    {
        GameManager.onGameLost += lostGame;
        SpawnObstacles();
    }
    void Awake()
    {
    }
    void Update()
    {
        gameObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy"))
        {
            Destroy(gameObject,1f);
        }
    }
    private void SpawnObstacles()
    {
        int spawnIndedx = Random.Range(0, 3);
        Debug.Log(spawnIndedx);
        GameObject n =  Instantiate(obtaclePrefab,
            obtacleSpawnPoint[spawnIndedx].position,
            obtacleSpawnPoint[spawnIndedx].rotation);
        n.transform.SetParent(gameObject.transform);
    }
    private void lostGame()
    {
        speed = 0;
    }   
}
