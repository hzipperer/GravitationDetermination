using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    private GameObject playerInfo;
    private Player player;
    public StatsMenu statsMenu;
    public LevelSelectMenu selectMenu;
    public TMP_Dropdown qualityDropdown;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        qualityDropdown.value = PlayerPrefs.GetInt("Quality", 0);
        QualitySettings.SetQualityLevel(qualityDropdown.value);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20f);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
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
