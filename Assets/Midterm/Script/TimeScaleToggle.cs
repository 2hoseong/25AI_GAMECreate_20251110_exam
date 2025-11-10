using UnityEngine;
using UnityEngine.InputSystem;

public class TimeScaleToggle : MonoBehaviour
{
    [Tooltip("인스펙터에서 기본 timeScale 세팅")]
    public float TimeSpeed = 1.0f;   // 시작 시 적용
    public float SlowMo = 0.3f;      // 토글 목표 값

    void Start()
    {
        Time.timeScale = Mathf.Clamp(TimeSpeed, 0f, 1f);
        Time.fixedDeltaTime = 0.02f * Time.timeScale; // 고정 업데이트도 비율 맞춤
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.tKey.wasPressedThisFrame)
        {
            Time.timeScale = (Mathf.Approximately(Time.timeScale, 1.0f)) ? SlowMo : 1.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
}
