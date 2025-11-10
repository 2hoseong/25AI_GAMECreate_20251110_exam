using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // ✅ 새 입력 시스템 추가

public class GameManager_Total : MonoBehaviour
{
    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        // ✅ 새 입력 시스템으로 교체
        if (isGameOver && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        Time.timeScale = 0f;
  
    }
}
