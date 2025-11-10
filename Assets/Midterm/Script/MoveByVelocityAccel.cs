using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveByVelocityAccel : MonoBehaviour
{
    public float moveAcceleration = 5.0f;
    public float maxSpeed = 4.0f;

    private Rigidbody2D rb;
    private Vector2 currentVelocity;

    public GameObject text;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Player : Game Over!");
            if (text != null)
                text.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            FindFirstObjectByType<GameManager_Total>().GameOver();
        }
    }

    void FixedUpdate()
    {
        float x = 0f;
        float y = 0f;

        if (Keyboard.current.leftArrowKey.isPressed) x -= 1;
        if (Keyboard.current.rightArrowKey.isPressed) x += 1;

        Vector2 targetDir = new Vector2(x, y).normalized;

        currentVelocity = Vector2.Lerp(
            currentVelocity,
            targetDir * maxSpeed,
            moveAcceleration * Time.fixedDeltaTime
        );

        rb.linearVelocity = currentVelocity;
    }

    // ✅ Spike 충돌 시 게임 정지
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            FindFirstObjectByType<GameManager_Total>().GameOver();
        }
    }
}
