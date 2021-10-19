using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int numberOfDeaths;
    public int numberOfFlips;
    public int timesPlayed;
    public int levelsBeaten;
    public bool[] levelUnlocked;

    public PlayerData (Player player)
    {
        numberOfDeaths = player.numberOfDeaths;
        numberOfFlips = player.numberOfFlips;
        timesPlayed = player.timesPlayed;
        levelsBeaten = player.levelsBeaten;

        levelUnlocked = new bool[11];

        player.levelUnlocked.CopyTo(levelUnlocked, 0);
    }

    public PlayerData()
    {
        numberOfDeaths = 0;
        numberOfFlips = 0;
        timesPlayed = 0;
        levelsBeaten = 0;

        levelUnlocked = new bool[11];

    }
}
