using UnityEngine;
using System.Collections;

public class SpikeSpawnerTop : MonoBehaviour
{

    public GameObject SpikePrefab;


    public float interval = 0.9f;


    public bool rotate180OnSpawn = true;   // 180도 뒤집어서 아래를 향하게
    public bool flipYOnSpawn = false;  // 스프라이트만 뒤집고 싶으면 사용

    public float initialDownSpeed = 0f;    // 0이면 부여 안 함

    void Start()
    {
        // 한 번만 생성하던 기존 Update 패턴을 → 반복 생성 코루틴으로 변경
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        var wait = new WaitForSeconds(interval);
        while (true)
        {
            SpawnOne();
            yield return wait;
        }
    }

    void SpawnOne()
    {
        // 1) 위치는 스포너 위치
        GameObject go = Instantiate(SpikePrefab, transform.position, Quaternion.identity);

        // 2) 회전/뒤집기: 아래를 향하게(거꾸로 된 삼각형)
        if (rotate180OnSpawn)
            go.transform.rotation = Quaternion.Euler(0f, 0f, 180f);

        if (flipYOnSpawn)
        {
            var sr = go.GetComponent<SpriteRenderer>();
            if (sr) sr.flipY = !sr.flipY;
        }

        // 3) 스케일은 스포너의 보이는 크기와 맞추고 싶으면(선택)
        go.transform.localScale = transform.lossyScale;

        // 4) Rigidbody2D가 있으면 초기 낙하 속도 부여(옵션)
        var rb = go.GetComponent<Rigidbody2D>();
        if (rb && initialDownSpeed > 0f)
            rb.linearVelocity = Vector2.down * initialDownSpeed;
    }
}
