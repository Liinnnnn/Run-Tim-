using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public Transform[] obtacleSpawnPoint;
    public GameObject[] obtaclePrefab;
    private List<GameObject> activeObstacles = new List<GameObject>();
    // Update is called once per frame
    void Start()
    {
        SpawnObstacle();
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
        // KIỂM TRA: Nếu đã có đủ 2 vật thể thì không sinh thêm nữa
        if (activeObstacles.Count >= 2)
        {
            Debug.Log("Đã đạt giới hạn 2 vật thể!");
            return; 
        }

        int randomIndex = Random.Range(0, obtacleSpawnPoint.Length);
        int randomObstcale = Random.Range(0, obtaclePrefab.Length);

        GameObject obstacle = Instantiate(
            obtaclePrefab[randomObstcale], 
            obtacleSpawnPoint[randomIndex].position, 
            obtaclePrefab[randomObstcale].transform.rotation
        );

        obstacle.transform.SetParent(gameObject.transform);

        // THÊM VÀO DANH SÁCH để quản lý
        activeObstacles.Add(obstacle);
    }
}
