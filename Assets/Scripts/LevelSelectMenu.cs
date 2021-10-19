using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class LevelSelectMenu : MonoBehaviour
{
    public GameObject[] levelButtons = new GameObject[11];
    private Player player;


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
