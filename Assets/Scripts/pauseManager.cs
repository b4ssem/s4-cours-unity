using UnityEngine;

public class poseManager : MonoBehaviour
{
    private bool isGamePaused = false;
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
    }
    private void Resume()
    {
        Time.timeScale = 1f;
    }
}
