using UnityEngine;

public class SpikeAction_Total : MonoBehaviour
{
    public float minSpeed = 3f; // 최소 속도
    public float maxSpeed = 8f; // 최대 속도
    private float speed;
    public float killY = -15f;

    void Start()
    {
        // 스폰될 때마다 랜덤 속도 부여
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        // 아래로 이동
        transform.position += Vector3.down * (speed * Time.deltaTime);

        // 화면 아래로 떨어지면 삭제
        if (transform.position.y < killY)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpikeDestroyer"))
        {
            Debug.Log("Spike : Trigger 소멸");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("SpikeDestroyer"))
        {
            Debug.Log("Spike : Collision 소멸");
            Destroy(gameObject);
        }
    }
}
