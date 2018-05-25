using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public float timeTillNextLevel = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //Load currentIndex + 1 when press space
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadNextScene();
            }
            if (timeTillNextLevel > 0)
                timeTillNextLevel = timeTillNextLevel - Time.deltaTime;
            // End Level
            if (timeTillNextLevel < 0)
            {
                LoadNextScene();
            }
            if (Input.GetButton("Replay"))
            {
                ReLoadScene();
            }
            if (Input.GetButton("Quit"))
            {
                LoadPreviousScene();
            }
        }
    }
    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
    public void LoadPreviousScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex - 1);
    }
    public void ReLoadScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
