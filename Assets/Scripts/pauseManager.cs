using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isGamePaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;

            if (isGamePaused == true)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
