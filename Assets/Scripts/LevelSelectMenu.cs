using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class LevelSelectMenu : MonoBehaviour
{
    public TextMeshProUGUI[] levelBestTimes = new TextMeshProUGUI[12];
    public GameObject[] levelButtons = new GameObject[11];
    private TimeSpan[] timePlaying = new TimeSpan[12];
    private string[] timePlayingStr = new string[12];
    private Player player;

    public void updateTimes()
    {
        player = GameObject.Find("PlayerInfo").GetComponent<Player>();
        for (int j = 0; j < player.levelTimes.Length; j++)
        {
            timePlaying[j] = TimeSpan.FromSeconds(player.levelTimes[j]);
            if (player.levelTimes[j] > 0)
            {
                timePlayingStr[j] = "Best Time:  " + timePlaying[j].ToString("mm':'ss'.'ff");
            }
            else
            {
                timePlayingStr[j] = "Best Time: --:--.--";
            }
            levelBestTimes[j].text = timePlayingStr[j];
        }
    }

    public void unlockLevels()
    {
        player = GameObject.Find("PlayerInfo").GetComponent<Player>();
        for (int j = 0; j < player.levelUnlocked.Length; j++)
        {
            if (player.levelUnlocked[j] == true)
            {
                levelButtons[j].GetComponent<Button>().interactable = true;
            }
            else
            {
                levelButtons[j].GetComponent<Button>().interactable = false;
            }
        }
    }
    

}
