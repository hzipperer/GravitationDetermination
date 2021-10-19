using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public float volume;
    private GameObject playerInfo;
    private Player player;
    public StatsMenu statsMenu;
    public LevelSelectMenu selectMenu;

    public void Update()
    {
        audioMixer.GetFloat("Volume", out volume);
        volumeSlider.value = volume;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Delete()
    {
        SaveSystem.DeleteSaves();
        player.LoadPlayer();
        statsMenu.updateStats();
        selectMenu.unlockLevels();
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    void Awake()
    {
        if (GameObject.Find("PlayerInfo") == null)
        {
            playerInfo = new GameObject("PlayerInfo");
            playerInfo.AddComponent<Player>();
            SaveSystem.CreateDirectory();
            player = playerInfo.GetComponent<Player>();
            if (SaveSystem.Load() == null)
            {
                player.SavePlayer();
            }
            else
            {
                player.LoadPlayer();
                player.increaseTimesPlayed();
                player.SavePlayer();
            }

        }
        else
        {
            playerInfo = GameObject.Find("PlayerInfo");
            SaveSystem.CreateDirectory();
            player = playerInfo.GetComponent<Player>();
            player.SavePlayer();
        }

    }
}
