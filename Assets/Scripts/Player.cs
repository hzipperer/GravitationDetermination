using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int numberOfDeaths = 0;
    public int numberOfFlips = 0;
    public int timesPlayed = 0;
    public int levelsBeaten = 0;
    public bool[] levelUnlocked = new bool[11];

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SavePlayer()
    {
        SaveSystem.Save(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.Load();

        numberOfDeaths = data.numberOfDeaths;
        numberOfFlips = data.numberOfFlips;
        timesPlayed = data.timesPlayed;
        levelsBeaten = data.levelsBeaten;

        data.levelUnlocked.CopyTo(levelUnlocked, 0);

    }

    public void increaseTimesPlayed()
    {
        timesPlayed += 1;
    }
}
