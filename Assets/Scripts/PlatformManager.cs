using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    // Update is called once per frame
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
}
