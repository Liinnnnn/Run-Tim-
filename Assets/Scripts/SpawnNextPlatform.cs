using UnityEngine;

public class SpawnNextPlatform : MonoBehaviour
{
    public GameObject platformPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(platformPrefab, new Vector3(0, -0.04f, 0.8f), Quaternion.identity);
        }
    }
}
