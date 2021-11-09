using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalMenu : MonoBehaviour
{
    public GameObject GoalMenuUI;
    public AudioSource sound;
    public static bool levelIsBeaten = false;


    // Update is called once per frame
    void Update()
    {
        if (levelIsBeaten)
        {
            PauseMenu.GameIsPaused = true;
            Pause();
        }
    }

    public void Resume()
    {
        GoalMenu.levelIsBeaten = false;
        GoalMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        sound.pitch = 1f;
    }

    public void NextLevel()
    {
        GoalMenu.levelIsBeaten = false;
        GoalMenuUI.SetActive(false);
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = false;
        sound.Stop();
    }

    void Pause()
    {
        GoalMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
        sound.pitch = .75f;
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
