using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector2 startPos;
    private Vector3 targetPos;
    private float targetedLane = 1;
    [Header("Cài đặt di chuyển")]
    public float swipeThreshold = 10f; // Độ dài tối thiểu của cú vuốt
    public float laneDistance = 0.2f;        // Khoảng cách mỗi lần di chuyển
    public float speed = 20f;          // Tốc độ trượt
    
    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        // 1. Xử lý nhận diện Vuốt (Swipe)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Lấy ngón tay đầu tiên chạm vào

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    Vector2 endPos = touch.position;
                    HandleSwipe(startPos, endPos);
                    break;
            }
        }

        if (targetedLane == 0) targetPos.x = -laneDistance;
        else if (targetedLane == 1) targetPos.x = 0;
        else if (targetedLane == 2) targetPos.x = laneDistance;

        // 3. Di chuyển mượt mà đến làn đường đó (chỉ di chuyển trục X)
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
    }

    void HandleSwipe(Vector2 start, Vector2 end)
    {
        float diffX = end.x - start.x;
        if (Mathf.Abs(diffX) > swipeThreshold)
        {
            if (diffX > 0) // Vuốt sang phải
            {
                if (targetedLane < 2) targetedLane++;
            }
            else // Vuốt sang trái
            {
                if (targetedLane > 0) targetedLane--;
            }
        }
       
    }
}
